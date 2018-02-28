
let i: boolean = true;
//布尔值
let isDone: boolean = false;
//数字
let decLiteral: number = 6;
let hexLiteral: number = 0xf00d;
let binaryLiteral: number = 0b1010;
let octalLiteral: number = 0o744;

//字符串
let eName: string = "bob";
eName = "Smith";
let age: number = 20;
let sentence = `Hello, my name is ${eName}.

I'll be ${age + 1} years old next month.`;

//数组
let list: number[] = [1, 2, 3];
let aList: Array<number> = [1, 2, 3];

//元组
let x: [number, string];

x = [10, "Hello"];

//console.log(x[0].substring(1));
console.log(x[1].substring(1));

x[3] = "World";

//console.log(x[5].toString());


//枚举

enum Ocolor {
    Red,
    Green,
    Blue,
    Yellow
};

let cB: Ocolor = Ocolor.Blue;

enum Tcolor {
    Red = 1,
    Green = 2,
    Blue = 3,
    Yellow = 4
}

let tB = Tcolor.Green;

//枚举类型提供的一个便利是你可以由枚举的值得到它的名字。 例如，我们知道数值为2，但是不确定它映射到Color里的哪个名字，我们可以查找相应的名字：
enum Color { Red = 1, Green, Blue }

let colorName: string = Color[2];

alert(colorName);


//Any 任何类型
let notSure: any = 4;
//notSure.ifItExists(); // okay, ifItExists might exist at runtime
notSure.toFixed(); // okay, toFixed exists (but the compiler doesn't check)

let prettySure: Object = 4;
//prettySure.toFixed(); // Error: Property 'toFixed' doesn't exist on type 'Object'.


let tlist: any[] = [1, true, "free"];

tlist[1] = 100;


//Void

function wareUser(): void {

    alert("this is my ware message");
}

let unusable: void = undefined;

//Null 和 Undefined

let u: any = undefined;
let n: any = null;

//never

function error(message: string): never {

    throw new Error(message);
}


function fail() {
    return error("Something failed");
}

//function infiniteLoop():never {

//    while (COND) {

//    }
//}
wareUser();


interface ILabelledValue {
    label: string;
}

function printLabel(labelledObj: ILabelledValue) {
    console.log(labelledObj.label);
}

let myObj = { size: 10, label: "Size 10 Object" };
printLabel(myObj);

class Animal {
    move(distanceInMeters: number = 0) {
        console.log(`Animal moved ${distanceInMeters}m.`);
    }
}

class Dog extends Animal {
    bark() {
        console.log("Woof! Woof!");
    }
}

const dog = new Dog();
dog.bark();
dog.move(10);
dog.bark();


let passcode = "secret passcode";

class Employee {
    private _fullName: string;

    get fullName(): string {
        return this._fullName;
    }

    set fullName(newName: string) {
        if (passcode && passcode == "secret passcode") {
            this._fullName = newName;
        } else {
            console.log("Error: Unauthorized update of employee!");
        }
    }
}

let employee = new Employee();
employee.fullName = "Bob Smiths";
if (employee.fullName) {
    alert(employee.fullName);
}

let content = `aaa
ccc
ddd`;

let sum = (arg1: any, arg2: any) => {
    return arg1 + arg2;
};

var myArray = [1, 2, 3, 4, 5];
console.log(myArray.filter(value => value % 2 == 0));//[2,4]


function getStock(name: string) {
    this.name = name;

    setInterval(function () {
        //let sentence = `Hello, my name is ${h}.I'll be ${age + 1} years old next month.`;
        let content = `name is ${this.name}`;
        console.log(content);
    }, 1000);
}
getStock("jianglk");


let  myArrays = [1, 2, 3, 4];
//myArray. = "four number";

myArrays.forEach(value => console.log(value));//1 2 3 4


//export let prop1:any;

//let prop2:any;

//export function fun1() {

//}
//function fun2() {

//}

//export class Clazz1 {

//}

//class Clazz2 {

//}

//export const numberRegexp = /^[0-9]+$/;





//import { } from "./Scripts/App";