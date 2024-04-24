// 1)
let salaries = {
  John: 100,
  Ann: 160,
  Pete: 130,
};

// Sum of Salaries

var sum = 0;
Object.values(salaries).forEach((i) => (sum += i));
console.log(" Sum is ", sum);

// 2)

function multiplyNumeric(params) {
  params= Object.keys(params).forEach((item)=>{
    params[item] = typeof params[item] =="string" ? params[item] : params[item]*2
  })
}

let menu = {
  width: 200,
  height: 300,
  title: "My menu",
};
multiplyNumeric(menu);

console.log(menu);

/*
    3. Write a function checkEmailId(str) that returns true if str contains '@' and ‘.’, otherwise false. Make sure
    '@' must come before '.' and there must be some characters between '@' and '.'
    The function must be case-insensitive:
*/



var email="abcd@text.com"

function checkEmailId(str) {
    if (str.includes('@') && str.includes('.')) {
        const atIndex = str.indexOf('@');
        const dotIndex = str.indexOf('.');
        if (atIndex < dotIndex) {
            if (dotIndex - atIndex > 1) {
                return true;
            }
        }
    }
    return false;
}

console.log(checkEmailId(email));


/*
    4. Create a function truncate(str, maxlength) that checks the length of the str and, if it exceeds maxlength
    – replaces the end of str with the ellipsis character "...", to make its length equal to maxlength.
    The result of the function should be the truncated (if needed) string.
    truncate("What I'd like to tell on this topic is:", 20) = "What I'd like to te..."
    truncate("Hi everyone!", 20) = "Hi everyone!"

*/
console.log(truncate("What I'd like to tell on this topic is:", 20))

function truncate(str,length) {
    if(str.length < length)
        return str

    return str.substring(0,length).concat("...");
}



/*
    5. Let’s try 5 array operations.
    Create an array styles with items “James” and “Brennie”.
    Append “Robert” to the end.
    */

    var arr=["James","Brennie"]
    arr.push("Robert")
    arr.splice(arr.length/2,1,"Calvin")
    arr.shift()
    arr.splice(0,0,"Rose","Regal")

    console.log(arr);
