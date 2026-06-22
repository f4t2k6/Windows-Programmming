import urllib.request
import json
import base64
import sys

api_key = "AQ.Ab8RN6JMcXEUvWKcAsE73pQhljKlOeRt_Smoxbk8s6ZKc7HApw"
url = f"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={api_key}"

image_data = base64.b64decode("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNkYAAAAAYAAjCB0C8AAAAASUVORK5CYII=")
b64_img = base64.b64encode(image_data).decode('utf-8')

payload = {
    "contents": [{
        "parts": [
            {"text": "Extract details as JSON"},
            {
                "inline_data": {
                    "mime_type": "image/png",
                    "data": b64_img
                }
            }
        ]
    }],
    "generationConfig": {
        "responseMimeType": "application/json"
    }
}

data = json.dumps(payload).encode('utf-8')
req = urllib.request.Request(url, data=data, headers={
    "Content-Type": "application/json"
})

try:
    with urllib.request.urlopen(req) as response:
        print(response.status)
        print(response.read().decode('utf-8'))
except urllib.error.HTTPError as e:
    print(e.code)
    print(e.read().decode('utf-8'))
