#==================================
# * Setup
#==================================
# Import modules
import os
import codecs
import json
import sys

# Define constants
Cytoid_player_directory = "Library/Application Support/TigerHix/Cytoid/player"
ECP_file_directory = "."#"Library/Application Support/Jono99/EasyCytoidPlayer"
Settings_file_path = ECP_file_directory + "/settings.txt"
System_clear_command = 'cls'#'clear'
Current_setting_file_version = 1
LevelJSON_file_name = "level.json"
Exit_string = "EXIT"

# Define classes
class CSettings:
    def __init__(self):
        self.cytoid_player_path = ""

    def load(self):
        _file = open_file(Settings_file_path)
        #_file = codecs.open(Settings_file_path, 'r', encoding='utf8')
        _settings = _file.read().splitlines()
        _file.close()
        if _settings[0] != str(Current_setting_file_version):
            _settings = convert_settings(_settings)
        for i in range(1, len(_settings)):
            if i == 1: # Cytoid player path
                self.cytoid_player_path = _settings[i]

    def convert(self, settings):
        return settings

    def save(self):
        _file = open_file(Settings_file_path, True)
        #_file = codecs.open(Settings_file_path, 'w', encoding='utf8')
        _file.write(str(Current_setting_file_version) + "\n" +\
                    self.cytoid_player_path)
        _file.close()

class CScene:
    def __init__(self, parent_scene=None):
        self.parent = parent_scene

    def start(self, *args):
        clear()
        self.run(args)

    def run(self, args):
        pass

# Define functions
def dict_from_json(json_data):
    return json.loads(json_data, encoding='utf8')

def json_from_dict(dictionary):
    return json.dumps(dictionary, ensure_ascii=False, encoding='utf8')

def open_file(path, write=False):
    _permission = 'r'
    if write:
        _permission = 'w'
    return codecs.open(path, _permission, encoding='utf8')

def clear():
    os.system(System_clear_command)

def mkdir(dir):
    _dir_split = dir.replace('\\', '/').split('/')
    _test_dir = "."
    for i in range(0, len(_dir_split)):
        _test_dir += '/' + _dir_split[i]
        if not os.path.isdir(_test_dir):
            os.mkdir(_test_dir)

def empty_dir(dir):
    for file in os.listdir(dir):
        _file = dir + '/' + file
        if os.path.isfile(_file):
            os.remove(_file)
        if os.path.isdir(_file):
            rmdir(_file)

def rmdir(dir):
    empty_dir(dir)
    os.rmdir(dir)

def copy_dir(dir, dest):
    os.mkdir(dest)
    for file in os.listdir(dir):
        _file = dir + '/' + file
        if os.path.isfile(_file):
            oldfile = open(_file, 'rb')
            newfile = open(dest + '/' + file, 'wb')
            newfile.write(oldfile.read())
            oldfile.close()
            newfile.close()
        if os.path.isdir(_file):
            copy_dir(_file, dest + '/' + file)

# Define class dependant constants
Settings = CSettings()

# Define scenes
class MainScene(CScene):
    def __init__(self):
        CScene.__init__(self)
        self.options_scene = OptionsScene()

    def run(self, args):
        if os.path.isfile(Settings_file_path):
            Settings.load()
        else:
            self.options_scene.start()
        self.give_chart_folder()

    def give_chart_folder(self):
        while True:
            print "Type in the path to the folder where your chart is, type in 'OPTIONS' to change your options or type 'EXIT' to exit the program"
            _path = raw_input()
            if _path == Exit_string:
                return
            elif _path == "OPTIONS":
                OptionsScene(self).start([])
            elif not os.path.isdir(_path):
                clear()
                print "INVALID: The folder \"" + _path + "\" does not exist."
            elif os.path.isfile(_path + '/' + LevelJSON_file_name):
                self.chart_folder = _path
                self.load_levelJSON()
                break
            else:
                clear()
                print "INVALID: The folder \"" + _path + "\" does not contain a \"level.json\" file."
        self.give_chart_difficulty()

    def load_levelJSON(self):
        _file = open_file(self.chart_folder + '/' + LevelJSON_file_name)
        self.levelJSON = dict_from_json(_file.read())
        _file.close()

    def give_chart_difficulty(self):
        _charts = []
        for i in range(0, len(self.levelJSON["charts"])):
            chart = self.levelJSON["charts"][i]
            if "name" in chart.keys():
                _charts.append(chart["name"])
            else:
                _charts.append(chart["type"].capitalize())
        
        clear()
        while True:
            print "Type in the number corresponding to the chart difficulty you want to preview."
            for i in range(0, len(_charts)):
                print str(i + 1) + ":", _charts[i]
            print "0: Exit"
            _chart = raw_input()
            if _chart == '0':
                return
            else:
                for i in range(0, len(_charts)):
                    if str(i + 1) == _chart:
                        self.chart_difficulty = self.levelJSON["charts"][i]
                        self.run_cytoid_player()
                        return
                clear()
                print "INVALID: The number inputted is not among the selection."

    def run_cytoid_player(self):
        # Copy level to play directory
        mkdir(Cytoid_player_directory) # Ensure that path to the directory exists
        rmdir(Cytoid_player_directory)
        copy_dir(self.chart_folder, Cytoid_player_directory)
        
        # Replace level.json
        _json = dict_from_json(json_from_dict(self.levelJSON))
        _json["charts"] = [self.chart_difficulty]
        _music = ""
        if "music_override" in _json["charts"][0].keys():
            _music = _json["charts"][0]["music_override"]["path"]
        else:
            _music = _json["music"]["path"]
        if (_music.split('.')[-1] == 'mp3'):
            _music = _music[0:-3] + "wav"
        _json["charts"][0]["music_override"] = {"path": _music}
        _file = open_file(Cytoid_player_directory + '/' + LevelJSON_file_name, True)
        _file.write(json_from_dict(_json))
        _file.close()

        # Run Cytoid Player
        print "executing..."
        os.system('"' + Settings.cytoid_player_path + "/Contents/MacOS/CytoidPlayer 1.5.2\"")
        print "executed"
        
class OptionsScene(CScene):
    def run(self, args):
        if Settings.cytoid_player_path == "":
            self.change_cytoid_player_path()
        else:
            self.select_option()

    def select_option(self):
        while True:
            clear()
            print "Select an option by inputting the option's number and pressing enter"
            print "1: Change Cytoid Player location"
            print "0: Exit menu"
            _command = raw_input()
            if _command == '1':
                self.change_cytoid_player_path()
            elif _command == '0':
                return

    def change_cytoid_player_path(self):
        while True:
            print "Type the path to the Cytoid Player app or type 'EXIT' to cancel out of this menu"
            _new_path = raw_input()
            if _new_path == "EXIT":
                return
            elif _new_path[-4:] != '.app':
                _new_path += '.app'
            print _new_path
            if os.path.isdir(_new_path):
                Settings.cytoid_player_path = _new_path
                Settings.save()
                return
            else:
                clear()
                print "The given app does not exist"
            

MainScene().start(sys.argv)
