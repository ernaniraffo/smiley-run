
format: Assets/Scripts/Managers/*.cs Assets/Scripts/Mechanics/*.cs Assets/Scripts/Objects/*.cs
	clang-format --style=file -i $^
