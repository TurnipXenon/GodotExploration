# -c = command
# -c lint = checks for linting errors in the entire godot project
# -c format = enforces linting in the entire project

while getopts c: flag
do
    case "${flag}" in
        c) command=${OPTARG};;
    esac
done

case $command in

    lint)
        echo "Checking for formatting problems in Godot files..."
        source env/Scripts/activate # activating bash in Windows 10 Git Bash
        pip3 install 'gdtoolkit==3.*' -q
        gdlint common scenes
        deactivate
        ;;

    format)
        echo "Formatting Godot files..."
        source env/Scripts/activate # activating bash in Windows 10 Git Bash
        pip3 install 'gdtoolkit==3.*' -q
        gdformat common scenes
        deactivate
        ;;

    *)
        echo -n "unknown"
        ;;
esac