# Compiler options
EscapeQuote1 = False
EscapeQuote2 = True
EncaseCurly = False
CompileToSh = False
AddExecPermissionsAfterCompile = True
# Note: AddExecPermissionsAfterCompile only works on Mac and Linux.

# Read in Main.py
file = open("Main.py", 'r')
script = file.read().splitlines()
file.close()

# Generate command file
path = "Library/Application Support/Jono99/EasyCytoidPlayer"
command = "cd ~\nmkdir -p \"Library/Application Support/Jono99\"\nmkdir -p \"" + path + "\"\n\n"
if EncaseCurly:
    command += "{\n"
for i in range(0, len(script)):
    line = script[i]
    line = line.replace("\\", "\\\\")
    if EscapeQuote1:
        line = line.replace('\'', '\\\'')
    if EscapeQuote2:
        line = line.replace("\"", "\\\"")
    command += "echo \"" + line + "\""
    if not EncaseCurly:
        command += " >> \"" + path + "/runtime.py\""
    command += "\n"

if EncaseCurly:
    command += "} >> \"" + path + "/runtime.py\"\n"
command += "\npython \"" + path + "/runtime.py\"\nrm \"" + path + "/runtime.py\""

# Save command file
filename = "Easy Cytoid Player."
if CompileToSh:
    filename += "sh"
else:
    filename += "command"

file = open(filename, 'w')
file.write(command)
file.close()

if (AddExecPermissionsAfterCompile):
    import os
    os.system("chmod u+x \"" + filename + "\"")
