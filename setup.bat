
@echo off

rem SmartPasterのインストールファイル
rem インストール内容
rem インストールフォルダ %ProgramFiles(x86)%\SmartPaster\
rem レジストリ変更場所 \HKEY_CASSES_ROOT\Directory\SmartPaster\

rem 作業フォルダの移動
cd /d %~dp0

rem 管理者権限の実行確認．権限がなければ終了
openfiles > nul
if errorlevel 1 echo 管理者権限で実行してください． & pause & exit /b 9999

mkdir "%ProgramFiles(x86)%\SmartPaster\"
copy ".\SmartPaster\bin\Release\SmartPaster.exe" "%ProgramFiles(x86)%\SmartPaster\"

reg add HKCR\Directory\Background\shell\SmartPaster
reg add HKCR\Directory\Background\shell\SmartPaster /ve /t REG_EXPAND_SZ /d "Clipboard to file" /f
reg add HKCR\Directory\Background\shell\SmartPaster\command
reg add HKCR\Directory\Background\shell\SmartPaster\command /ve /t REG_EXPAND_SZ /d "%ProgramFiles(x86)%\SmartPaster\SmartPaster.exe"

echo インストールが完了しました．
pause

exit /b 0