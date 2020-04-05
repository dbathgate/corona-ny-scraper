
run-tests:
	dotnet test

compile: run-tests
	dotnet publish src/CoronaNyScaper -c Release --self-contained -r linux-x64 -o publish

push: compile
	cf push