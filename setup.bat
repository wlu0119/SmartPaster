
@echo off

rem SmartPaster�̃C���X�g�[���t�@�C��
rem �C���X�g�[�����e
rem �C���X�g�[���t�H���_ %ProgramFiles(x86)%\SmartPaster\
rem ���W�X�g���ύX�ꏊ \HKEY_CASSES_ROOT\Directory\SmartPaster\

rem ��ƃt�H���_�̈ړ�
cd /d %~dp0

rem �Ǘ��Ҍ����̎��s�m�F�D�������Ȃ���ΏI��
openfiles > nul
if errorlevel 1 echo �Ǘ��Ҍ����Ŏ��s���Ă��������D & pause & exit /b 9999

mkdir "%ProgramFiles(x86)%\SmartPaster\"
copy ".\SmartPaster\bin\Release\SmartPaster.exe" "%ProgramFiles(x86)%\SmartPaster\"

reg add HKCR\Directory\Background\shell\SmartPaster
reg add HKCR\Directory\Background\shell\SmartPaster /ve /t REG_EXPAND_SZ /d "Clipboard to file" /f
reg add HKCR\Directory\Background\shell\SmartPaster\command
reg add HKCR\Directory\Background\shell\SmartPaster\command /ve /t REG_EXPAND_SZ /d "%ProgramFiles(x86)%\SmartPaster\SmartPaster.exe"

echo �C���X�g�[�����������܂����D
pause

exit /b 0