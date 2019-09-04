**We don't expect the answer to be perfect and we don't expect you to finish all. It's open book feel free to hit Google but be prepared to explain your solution.**

**Good luck!**


### 1. Recreate this 

##### Before login


<img src="https://i.ibb.co/x5KBLWZ/before-login.png" alt="before-login" border="0" width="350">
<img src="https://i.ibb.co/C8n2rbQ/before-login-mobile.png" alt="before-login-mobile" border="0" width="150">


##### After login


<img src="https://i.ibb.co/YbtQcgt/after-login.png" alt="after-login" border="0"  width="350">
<img src="https://i.ibb.co/BNP5r53/after-login-mobile.png" alt="after-login-mobile" border="0" width="150">


notes: use any color palette, icons, logo available to you


### 2. Consider this following array of objects

	
```
var arr = [{
  name: 'Clark Kent',
  alterEgo: 'Superman',
  gender: 'Male',
  powers: ['super human strength', 'flight', 'x-ray vision', 'heat vision']
}, {
  name: 'Barry Allen',
  alterEgo: 'The Flash',
  gender: 'Male',
  powers: ['super speed', 'phasing', 'time travel', 'dimensional travel']
}, {
  name: 'Diana Prince',
  alterEgo: 'Wonder Woman',
  gender: 'Female',
  powers: ['super human strength', 'super human reflexes', 'super human agility', 'flight']
}, {
  name: 'Bruce Banner',
  alterEgo: 'The Hulk',
  gender: 'Male',
  powers: ['super human strength', 'thunder clap', 'super healing factor']
}, {
  name: 'Wade Wilson',
  alterEgo: 'Deadpool',
  gender: 'Male',
  powers: ['super healing factor', 'super human agility']
}, {
  name: 'Jean Grey',
  alterEgo: 'Phoenix',
  gender: 'Female',
  powers: ['telepathy', 'telekinesis', 'rearrange matter at will']
}, {
  name: 'Wanda Maximoff',
  alterEgo: 'Scarlet Witch',
  gender: 'Female',
  powers: ['reality manipulation', 'astral projection', 'psionic']
}]
```

* Take only the `alterEgo`

	```
	desired result
	[
		'Superman', 
		'The Flash', 
		'Wonder Woman', 
		'The Hulk', 
		'Deadpool', 
		'Phoenix', 
		'Scarlet Witch'
	]
	```

* Take only the `powers`

	```
	desired result
  	[
  	  'astral projection',
  	  'dimensional travel',
  	  'flight',
  	  'heat vision',
  	  'phasing',
  	  'psionic',
  	  'reality manipulation',
  	  'rearrange matter at will',
  	  'super healing factor'
  	  'super human agility',
  	  'super human reflexes',
  	  'super human strength',
  	  'super speed',
  	  'telekinesis',
  	  'telepathy',
  	  'thunder clap',
  	  'time travel',
  	  'x-ray vision',
  	]
  ```
  	
* Group them by gender

	```
	desired result
  	[{
	  gender: 'Female'
	  heroes: [
	    {
	      name: 'Jean Grey',
	      alterEgo: 'Phoenix',
	      powers: ['telepathy', 'telekinesis', 'rearrange matter at will']
	    },
	    ...
	  ]
	}, {
	  gender: 'Male'
	  heroes: [
	    {
	      name: 'Wade Wilson',
	      alterEgo: 'Deadpool',
	      gender: 'Male',
	      powers: ['super healing factor', 'super human agility']
	    },
	    ...
	  ]
	}]
    ```
    
* Transform and transpose them into

	```
   [
	  ['Name', 'Alter Ego', 'Gender']
	  ['Clark Kent', 'Superman', 'Male']
	  ['Barry Allen', 'The Flash', 'Male']
	  ['Diana Prince', 'Wonder Woman', 'Female']
	]
	```


### 3. Refactor this

```
/* 
happens to be in js (and prefer to also answer in js), 
but its upto you if you would like to rewrite this using any other language
*/

function setTitle(string) {
  var splitted = string.split(' ');
  var arr = [];
  for (var i = 0; i < splitted.length; i++) {
    arr.push(splitted[i][0].toUpperCase() + splitted[i].substring(1));
  }
  var title = arr.join(' ');
  return title;
}
```

### 4. Structure a normalise database using the following table


Fullname       | Gender  | Powers               | Address      | City    | Country   |
---------------| --------| ---------------------|--------------|---------|-----------|
Clark Kent     | Male    | super human strength | 123 A street | Jakarta | Indonesia |
Clark Kent     | Male    | flight               | 333 A street | Jakarta | Indonesia |
Clark Kent     | Male    | x-ray vision         | 234 A street | Jakarta | Indonesia |
Clark Kent     | Male    | heat vision          | 123 A street | Jakarta | Indonesia |
Barry Allen    | Male    | super speed          | 321 A street | Jakarta | Indonesia |
Barry Allen    | Male    | phasing              | 122 A street | Jakarta | Indonesia |
Barry Allen    | Male    | time travel          | 111 A street | Jakarta | Indonesia |
Barry Allen    | Male    | dimensional travel   | 221 A street | Jakarta | Indonesia |
Diana Prince   | Female  | super human strength | 432 A street | Jakarta | Indonesia |
Diana Prince   | Female  | super human reflexes | 453 A street | Jakarta | Indonesia |
Diana Prince   | Female  | super human agility  | 132 A street | Jakarta | Indonesia |
Diana Prince   | Female  | super human flight   | 231 A street | Jakarta | Indonesia |
Bruce Banner   | Male    | super human strength | 521 A street | Jakarta | Indonesia |
Bruce Banner   | Male    | thunder clap         | 444 A street | Jakarta | Indonesia |
Bruce Banner   | Male    | super healing factor | 222 A street | Jakarta | Indonesia |
Wanda Maximoff | Female  | reality manipulation | 524 A street | Jakarta | Indonesia |
Wanda Maximoff | Female  | astral projection    | 324 A street | Jakarta | Indonesia |
Wanda Maximoff | Female  | psionic              | 635 A street | Jakarta | Indonesia |


### 5. Based on your answer from the above's problem, design an API (get, post, put, delete) with as many as endpoints you can think of


### 6. API Implementation and integration

Make a simple GET API that take two arguments, the first argument would be a string, the second argument would be an object containing two keys (source and target) with ISO-639-1 country Code as values. That will return the translated version of the first argument

for example:

```
GET /translate

request: {
	params: {
		string: 'saya mau makan'
		data: {
			source: 'id',
			target: 'en'
		}
	}
}

result: {
	data: 'i want to eat'
}
```


### 7. Real world simulation

Let say that you have a digital company that produce a digital "Martabak mie", to make one "Martabak mie" you will have to do the following

1. Boil the noodle for a short time
2. Stir the noodle together with its seasoning and a couple of eggs
3. Heat the frying pan 
4. Fry the stirred noodle
5. Serve the "martabak mie" on a plate

Build a small service (backend) surrounding those business requirements

Note: consider high and concurrent traffic will happen, and to also measure throughput and latency if possible 
