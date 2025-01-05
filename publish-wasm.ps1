# dotnet publish "src\BlazorUnicodeServer\BlazorUnicodeServer.csproj" --self-contained -r win-x64 -c Release -o dist/win-x64
dotnet publish `
	"src\BlazorUnicode\BlazorUnicode.csproj" `
	-c Release `
	-o wasm/
