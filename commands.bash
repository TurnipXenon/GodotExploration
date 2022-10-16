# -c = command
# -c lint = checks for linting errors in the entire godot project
# -c format = enforces linting in the entire project
# todo(turnip): more documentation

while getopts c: flag; do
  case "${flag}" in
  c) command=${OPTARG} ;;
  *) eval "echo \"invalid flag ${flag}\"" ;;
  esac
done

# $1: required argument: gdlint vs gdformat
run_gdtoolkit() {
  source env/Scripts/activate # activating bash in Windows 10 Git Bash
  #  pip3 install 'gdtoolkit==3.*' -q # for stable version
  python -m pip install --upgrade pip -q
  if [ ! -d "./godot-gdscript-toolkit" ]; then
    git clone https://github.com/Scony/godot-gdscript-toolkit.git
  fi
  pip3 install -e godot-gdscript-toolkit -q
  eval "$1 common scenes"
  deactivate
}

case $command in

lint)
  echo "Checking for formatting problems in Godot files..."
  run_gdtoolkit "gdlint"
  ;;

format)
  echo "Formatting Godot files..."
  run_gdtoolkit "gdformat"
  ;;

*)
  echo -n "unknown"
  ;;
esac
