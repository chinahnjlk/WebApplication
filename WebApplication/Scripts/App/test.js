var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var i = true;
//布尔值
var isDone = false;
//数字
var decLiteral = 6;
var hexLiteral = 0xf00d;
var binaryLiteral = 10;
var octalLiteral = 484;
//字符串
var eName = "bob";
eName = "Smith";
var age = 20;
var sentence = "Hello, my name is " + eName + ".\n\nI'll be " + (age + 1) + " years old next month.";
//数组
var list = [1, 2, 3];
var aList = [1, 2, 3];
//元组
var x;
x = [10, "Hello"];
//console.log(x[0].substring(1));
console.log(x[1].substring(1));
x[3] = "World";
//console.log(x[5].toString());
//枚举
var Ocolor;
(function (Ocolor) {
    Ocolor[Ocolor["Red"] = 0] = "Red";
    Ocolor[Ocolor["Green"] = 1] = "Green";
    Ocolor[Ocolor["Blue"] = 2] = "Blue";
    Ocolor[Ocolor["Yellow"] = 3] = "Yellow";
})(Ocolor || (Ocolor = {}));
;
var cB = Ocolor.Blue;
var Tcolor;
(function (Tcolor) {
    Tcolor[Tcolor["Red"] = 1] = "Red";
    Tcolor[Tcolor["Green"] = 2] = "Green";
    Tcolor[Tcolor["Blue"] = 3] = "Blue";
    Tcolor[Tcolor["Yellow"] = 4] = "Yellow";
})(Tcolor || (Tcolor = {}));
var tB = Tcolor.Green;
//枚举类型提供的一个便利是你可以由枚举的值得到它的名字。 例如，我们知道数值为2，但是不确定它映射到Color里的哪个名字，我们可以查找相应的名字：
var Color;
(function (Color) {
    Color[Color["Red"] = 1] = "Red";
    Color[Color["Green"] = 2] = "Green";
    Color[Color["Blue"] = 3] = "Blue";
})(Color || (Color = {}));
var colorName = Color[2];
alert(colorName);
//Any 任何类型
var notSure = 4;
//notSure.ifItExists(); // okay, ifItExists might exist at runtime
notSure.toFixed(); // okay, toFixed exists (but the compiler doesn't check)
var prettySure = 4;
//prettySure.toFixed(); // Error: Property 'toFixed' doesn't exist on type 'Object'.
var tlist = [1, true, "free"];
tlist[1] = 100;
//Void
function wareUser() {
    alert("this is my ware message");
}
var unusable = undefined;
//Null 和 Undefined
var u = undefined;
var n = null;
//never
function error(message) {
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
function printLabel(labelledObj) {
    console.log(labelledObj.label);
}
var myObj = { size: 10, label: "Size 10 Object" };
printLabel(myObj);
var Animal = /** @class */ (function () {
    function Animal() {
    }
    Animal.prototype.move = function (distanceInMeters) {
        if (distanceInMeters === void 0) { distanceInMeters = 0; }
        console.log("Animal moved " + distanceInMeters + "m.");
    };
    return Animal;
}());
var Dog = /** @class */ (function (_super) {
    __extends(Dog, _super);
    function Dog() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Dog.prototype.bark = function () {
        console.log("Woof! Woof!");
    };
    return Dog;
}(Animal));
var dog = new Dog();
dog.bark();
dog.move(10);
dog.bark();
var passcode = "secret passcode";
var Employee = /** @class */ (function () {
    function Employee() {
    }
    Object.defineProperty(Employee.prototype, "fullName", {
        get: function () {
            return this._fullName;
        },
        set: function (newName) {
            if (passcode && passcode == "secret passcode") {
                this._fullName = newName;
            }
            else {
                console.log("Error: Unauthorized update of employee!");
            }
        },
        enumerable: true,
        configurable: true
    });
    return Employee;
}());
var employee = new Employee();
employee.fullName = "Bob Smiths";
if (employee.fullName) {
    alert(employee.fullName);
}
var content = "aaa\nccc\nddd";
var sum = function (arg1, arg2) {
    return arg1 + arg2;
};
var myArray = [1, 2, 3, 4, 5];
console.log(myArray.filter(function (value) { return value % 2 == 0; })); //[2,4]
function getStock(name) {
    this.name = name;
    setInterval(function () {
        //let sentence = `Hello, my name is ${h}.I'll be ${age + 1} years old next month.`;
        var content = "name is " + this.name;
        console.log(content);
    }, 1000);
}
getStock("jianglk");
var myArrays = [1, 2, 3, 4];
//myArray. = "four number";
myArrays.forEach(function (value) { return console.log(value); }); //1 2 3 4
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
//# sourceMappingURL=test.js.map