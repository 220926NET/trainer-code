// if (true) {
//     var foo = 'bar'; //this variable will escape this scope
//     let bar = 'foo';
// }

// console.log(foo); //'bar'
// // console.log(bar); //reference error. Let is block scoped

// //if foo is truthy (as in, not an empty string, not undefined, not null, etc)
// if(foo) {
// //execute this block
// }

buttonClickHandler(); //this works, calling a function before the declaration
// greet(); //this doesn't work //will throw reference error
// sayHi(); //basically i'm trying to execute undefined, null reference.

function buttonClickHandler(/*any parameter goes in here*/ ) {
    console.log('hello!');
}

let greet = function(name) {
    console.log(`hello ${name}!`); //"hello 'name'!"
}

var sayHi = () => {
    console.log('hi!');
}

let printEventInfo = (e) => {
    console.log(e);
    e.stopPropagation();
}
