import urllib.request
import json
import base64

api_key = "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"
url = "https://api.groq.com/openai/v1/chat/completions"

image_data = base64.b64decode("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNkYAAAAAYAAjCB0C8AAAAASUVORK5CYII=")
b64_img = base64.b64encode(image_data).decode('utf-8')
data_uri = f"data:image/png;base64,{b64_img}"

payload = {
    "model": "llama-3.2-90b-vision-preview",
    "messages": [
        {
            "role": "user",
            "content": [
                {"type": "text", "text": "Extract details"},
                {"type": "image_url", "image_url": {"url": data_uri}}
            ]
        }
    ],
    "temperature": 0.1
}

data = json.dumps(payload).encode('utf-8')
req = urllib.request.Request(url, data=data, headers={
    "Authorization": f"Bearer {api_key}",
    "Content-Type": "application/json"
})

try:
    with urllib.request.urlopen(req) as response:
        print(response.status)
        print(response.read().decode('utf-8'))
except urllib.error.HTTPError as e:
    print(e.code)
    print(e.read().decode('utf-8'))
