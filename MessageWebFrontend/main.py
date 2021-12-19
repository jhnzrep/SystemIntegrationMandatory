from flask import Flask, render_template, url_for, request, redirect
import requests, json, random
from flask_cors import CORS, cross_origin

app = Flask(__name__)
cors = CORS(app)
cors = CORS(app, resources={r"/api/*": {"origins": "*"}})
url = 'https://fatsms.com/api-log-in'
url_sendSMS = 'https://fatsms.com/send-sms'

generateNewCode = 0

@app.route('/')
def home(name=None):
    return render_template('index.html')

@app.route('/log-in', methods=['GET','POST'])
def login():
    payload = {'email': 'matus@test.com', 'password': 'matusadmin'}
    if request.method == 'POST':
        response = requests.post(
            url,
            data=payload
        )
    return response.content

@app.route('/send-sms', methods=['POST'])
def sendSms():
    global generateNewCode
    generateNewCode = generateCode()
    payload = {'to_phone': '50157383', 'message': generateNewCode, 'api_key': '6e8067b7-80b8-412f-abc2-4cc356dfd8bd'}
    if request.method == 'POST':
        response = requests.post(
            url_sendSMS,
            data=payload
        )
    return response.content

@app.route('/check-code', methods=['POST'])
def checkCode():
    reqToString = request.data.decode("utf-8") 
    if(int(reqToString) == generateNewCode ):
        return 'True'
    return 'False'

@app.route('/dashboard', methods=['POST'])
def code():
    return render_template('dashboard.html')

def generateCode():
    number = random.randint(1000,9999)
    return number

app.run()