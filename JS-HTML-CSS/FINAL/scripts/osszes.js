
var osszesMegjelen = document.getElementById('osszesMegjelen');
var rendezArLegolcsobbMegjelen = document.getElementById('rendezArLegolcsobb'); 

var select = document.getElementById('select');

function rendezArLegolcsobb(){
   rendezArLegolcsobbMegjelen.innerHTML = '';
   osszesMegjelen.innerHTML ='';
   keressArraTable.innerHTML ='';
 
 for(var i = 0;  i < butorData.length; i++ ){
    for(var j = i+1; j< butorData.length; j++){
        if(select.value == "legolcsobb"){
            if(butorData[i][kulcs="price"] > butorData[j][kulcs="price"]){
            var temp = [butorData[i], butorData[j]];
            butorData[i] = temp[1];
            butorData[j] = temp[0];
            }
        }
        if(select.value == "legdragabb"){
            if(butorData[i][kulcs="price"] < butorData[j][kulcs="price"]){
            var temp = [butorData[i], butorData[j]];
            butorData[i] = temp[1];
            butorData[j] = temp[0];
            }    
        }  
        if(select.value == "legnepszerubb"){
            if(butorData[i][kulcs="popularity"] > butorData[j][kulcs="popularity"]){
            var temp = [butorData[i], butorData[j]];
            butorData[i] = temp[1];
            butorData[j] = temp[0];
            }
        }
    }
   
  }
   
   print(butorData);
} 

var osszesBegyujtTomb;
 function osszesBegyujt(){
    rendezArLegolcsobbMegjelen.innerHTML = '';
    osszesMegjelen.innerHTML ='';
    keressArraTable.innerHTML ='';

   osszesBegyujtTomb = [];

for (i=0; i<butorData.length; i++){
    osszesBegyujtTomb.push(butorData[i]);                       
            }
            print(osszesBegyujtTomb);
        }
 