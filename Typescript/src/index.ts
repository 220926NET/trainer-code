console.log('hello world!');
// a way to define your custom object shape
interface pokemon {
    id : number,
    name : string,
    //optional property
    type? : string,
    //union types
    dateCaught? : Date | string
}

let foo : string = 'bar';

function sayHi() : void {
    console.log('hi!');
}

function sum(a : number = 0, b : number = 0) : number {
    return a + b;
}

let summed : number = sum(3, 5);

let pokeObj : pokemon = {
    id : 1,
    name : 'Bulbasaur',
};

function printPokemon(poke : pokemon) {
    let foo = 'bar'
    console.log(`Id: ${poke.id} \nName: ${poke.name}`);
}

printPokemon(pokeObj);

let obj : any = {
    id: 7,
    name: 'Squirtle',
    otherProps: 'hello',
    i : 'dont belong in pokemon interface'
}

printPokemon(obj);