# KeyPadPhoneMessageConverter
This is a small project that simulates messaging using an old-style keypad phone. 
The project replicates the experience of typing text messages on traditional mobile phones, where each numeric key is associated with multiple letters.

# Features
1) Simulates multi-tap input from old-style phone keypads.
2) Supports character selection using numeric key presses.
3) Helps users understand the mechanics of old-style texting.

# How it works
Key Mapping: Each numeric key (0–9) corresponds to multiple characters. 
For example:

=> 2 → A, B, C
=> 3 → D, E, F
=> 7 → P, Q, R, S

Character Selection: Press the same key multiple times to cycle through the associated characters. 
For instance:

Press 2 once for A.
Press 2 twice quickly for B.
Press 2 three times quickly for C.
Output Message: The program collects the inputs and displays the typed message.
For example: For 222 2 22, the output will be CAB.

# Getting Started
# Prerequisites

1) .NET SDK (for running the program).
2) A basic understanding of console applications.

# Installation
# Clone the repository:
git clone https://github.com/MyatHsuMon23/KeyPadPhoneMessageConverter.git

# Usage
1) Run the program.
2) Enter numeric key presses to convert messages.
3) The program will display the typed nemeric keys as messages (Alphabetical letters).

# Example
Input: 222 2 22#
Output: CAB


