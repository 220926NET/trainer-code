// See https://aka.ms/new-console-template for more information
using asyncawaitdemo;

Console.WriteLine("Hello, World!");

AsyncMethods ams = new AsyncMethods();

//this code block will run synchronously
// string am1ret = await ams.Am1();
// string am2ret = await ams.Am2();
// string am3ret = await ams.Am3();
// string am4ret = await ams.Am4();
// string am5ret = await ams.Am5();

// Console.WriteLine($"{am1ret}{am2ret}{am3ret}{am4ret}{am5ret}");

//this code block will run asynchronously
// a task is an object that represents the potentially (un)returned data from a call.
Task<string> am1task = ams.Am1();
Task<string> am2task = ams.Am2();
Task<string> am3task = ams.Am3();
Task<string> am4task = ams.Am4();
Task<string> am5task = ams.Am5();

string am1str = await am1task;// the await keyword blocks progression forwward till the Task is resuolved.
Console.WriteLine("Hello,");
string am2str = await am2task;
Console.WriteLine("you");

string am3str = await am3task;
Console.WriteLine("are");

string am4str = await am4task;
Console.WriteLine("waiting");

string am5str = await am5task;
Console.WriteLine("for am2 to finish....");

Console.WriteLine($"{am1str}{am2str}{am3str}{am4str}{am5str}");




