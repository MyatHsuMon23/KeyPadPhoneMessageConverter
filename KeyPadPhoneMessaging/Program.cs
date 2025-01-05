using KeyPadPhoneMessaging;

Console.WriteLine($"Converted Output of \"222 2 22#\"=> {KeyPad.OldPhonePad("222 2 22#")}");
Console.WriteLine($"Converted Output of \"33#\"=> {KeyPad.OldPhonePad("33#")}");
Console.WriteLine($"Converted Output of \"227*#\"=> {KeyPad.OldPhonePad("227*#")}");
Console.WriteLine($"Converted Output of \"4433555 555666#\"=> {KeyPad.OldPhonePad("4433555 555666#")}");
Console.WriteLine($"Converted Output of \"8 88777444666*664#\"=> {KeyPad.OldPhonePad("8 88777444666*664#")}");

while (true)
{
    Console.WriteLine("Please enter the input string (use # to signify the end of input):");
    string input = Console.ReadLine();
    Console.WriteLine($"Converted Output of {input} => {KeyPad.OldPhonePad(input)}");
}