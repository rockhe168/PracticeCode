cd /d %~dp0
echo. > ../vacation_global.js
for /f %%i in (bin/global_file_list.txt) do (
	type %%i >> ../vacation_global.js
	echo. >> ../vacation_global.js
)

java -jar bin/yuicompressor-2.4.7.jar --type js --charset utf-8 -o ../vacation_global.js -o ../vacation_global.min.js

pause