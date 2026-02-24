from flask import Flask, render_template, request, jsonify
from deep_translator import GoogleTranslator
import requests

from model import StoryGenerator
app = Flask(__name__)
model = StoryGenerator()

@app.route('/')
def home():
    return render_template('index.html')

@app.route('/generate', methods=['POST'])
def generate_text():
    data = request.json
    input_text = data.get("text", "")
    output = model.generate(input_text)
    return jsonify({"result": output})


@app.route('/translate', methods=['POST'])
def translate():
    data = request.json
    text = data.get("text", "")
    language = data.get("language", "en")

    try:
        translated = GoogleTranslator(source='auto', target=language).translate(text)
        return jsonify({"result": translated})
    except Exception as e:
        print("Translation error:", e)
        return jsonify({"result": "Translation failed"}), 500
@app.route('/generate-image', methods=['POST'])
def generate_image():
    data = request.json
    prompt = data.get("text", "")

    # Simple dynamic image from Unsplash
    image_url = f"https://source.unsplash.com/800x400/?{prompt}"

    return jsonify({"image_url": image_url})

if __name__ == '__main__':
    app.run(debug=True)