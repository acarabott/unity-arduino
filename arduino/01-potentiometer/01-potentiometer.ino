// Read a single sensor and output the value via Serial

const int potPin = A0;

const float analogMax = 1023.0f;

// the setup funciton runs once when you press reset
void setup() {
  // initialize serial communication at 9600 bits per second
  Serial.begin(9600);

  // wait until the Serial port is available
  while (!Serial) continue;
}

// the loop routine runs over and over again forever
void loop() {
  // read the input on analog pin 0:
  const int potValue = analogRead(potPin);

  // scale it to be between 0.0 and 1.0
  const float potScaled = potValue / analogMax;

  // output the scaled value via serial
  Serial.println(potScaled);
}
