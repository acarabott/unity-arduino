// Read two sensors, output the values via Serial separated by a comma

const int potPin = A0;
const int buttonPin = 2;

const float analogMax = 1023.0f;

void setup() {
  Serial.begin(9600);
  while (!Serial) continue;

  // set the button pin as an input
  pinMode(buttonPin, INPUT);
}

void loop() {
  // read the pot
  const int potValue = analogRead(potPin);
  const float potScaled = potValue / analogMax;

  // read the button
  const int buttonState = digitalRead(buttonPin);

  // print the scaled pot value and the button state, separated by a comma
  Serial.print(potScaled);
  Serial.print(",");
  Serial.println(buttonState);
}
