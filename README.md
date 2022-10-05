# Godot Exploration

Exploration time! :)c

Where the roadmap or plan is: [Github Projects](https://github.com/users/TurnipXenon/projects/5)

## GDScript toolkit for manually linting (optional but recommended)

<!-- todo: better documentation herer -->
### Requirements

1. [Python3](https://www.python.org/downloads/)
2. [pip for Python3](https://pypi.org/project/pip/)
3. virtualenv (highly recommended): follow [installing virtualenv](https://packaging.python.org/en/latest/guides/installing-using-pip-and-virtual-environments/#installing-virtualenv)
and creating a [virtual environment](https://packaging.python.org/en/latest/guides/installing-using-pip-and-virtual-environments/#creating-a-virtual-environment). It's okay to stick to calling your virtual environment as `env`, we have that in our `.gitignore`.
4. [pip package gdtoolkit](https://github.com/Scony/godot-gdscript-toolkit#installation). Remember to be in the virtualenv if you're
installing this one! At least when you plan on using one.
5. Bash shell for your OS is optional but recommended for the one liner command and no directory switching. For Windows, you can just use Git Bash, it works.

#### Troubleshooting

The official Python docs for installing and running the virtual environment doesn't
work for me. What works on Windows 10 Git Bash for me is the following:

```bash
python -m venv env
source env/Scripts/activate # this once has source instead of default without one
```

### How-to lint

#### Easy way using bash

```bash
bash commands.bash -c lint
```

#### Manually
