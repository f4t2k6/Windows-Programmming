import urllib.request
import json
import base64

api_key = "AQ.Ab8RN6JMcXEUvWKcAsE73pQhljKlOeRt_Smoxbk8s6ZKc7HApw"
models_to_test = [
    "gemini-2.5-computer-use-preview-10-2025",
    "antigravity-preview-05-2026",
    "deep-research-max-preview-04-2026"
]

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
    }]
}

data = json.dumps(payload).encode('utf-8')

for model in models_to_test:
    print(f"Testing {model}...")
    url = f"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={api_key}"
    req = urllib.request.Request(url, data=data, headers={"Content-Type": "application/json"})
    try:
        with urllib.request.urlopen(req) as response:
            print(f"Success! Status: {response.status}")
            print(response.read().decode('utf-8'))
            break
    except urllib.error.HTTPError as e:
        print(f"Error {e.code}:")
        print(e.read().decode('utf-8'))
