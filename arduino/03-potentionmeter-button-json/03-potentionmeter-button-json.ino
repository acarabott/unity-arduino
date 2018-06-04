#include "ArduinoJson-v5.13.2.hpp";

const int potPin = A0;
const int buttonPin = 2;

const float analogMax = 1023.0f;

void setup() {
  Serial.begin(9600);
  while (!Serial) continue;

  pinMode(buttonPin, INPUT);
}

void loop() {
  // read the pot
  const int potValue = analogRead(potPin);
  const float potScaled = potValue / analogMax;

  // read the button
  const int buttonState = digitalRead(buttonPin);
  const bool isButtonDown = buttonState == 1;

  // create our JSON object
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& jsonData = jsonBuffer.createObject();

  jsonData["potValue"] = potScaled;
  // jsonData["buttonState"] = buttonState;
  jsonData["isButtonDown"] = isButtonDown;

  // send the JSON data via serial
  jsonData.printTo(Serial);
  Serial.println();
}
