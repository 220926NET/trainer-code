"use strict";
console.log('hello world!');
let foo = 'bar';
function sayHi() {
    console.log('hi!');
}
function sum(a = 0, b = 0) {
    return a + b;
}
let summed = sum(3, 5);
let pokeObj = {
    id: 1,
    name: 'Bulbasaur',
};
function printPokemon(poke) {
    let foo = 'bar';
    console.log(`Id: ${poke.id} \nName: ${poke.name}`);
}
printPokemon(pokeObj);
let obj = {
    id: 7,
    name: 'Squirtle',
    otherProps: 'hello',
    i: 'dont belong in pokemon interface'
};
printPokemon(obj);