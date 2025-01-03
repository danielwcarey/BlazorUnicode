Start-Process "docker" -ArgumentList "run --rm --name blazorunicode -p 8080:8080 blazorunicode"
Start-Sleep -Seconds 5
Start-Process "http://localhost:8080"
