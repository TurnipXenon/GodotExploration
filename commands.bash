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
        echo -n "Checking for formatting problems in Godot files"
        gdlint common scenes
        ;;

    format)
        echo -n "Formatting Godot files"
        gdlint common scenes
        ;;

    *)
        echo -n "unknown"
        ;;
esac