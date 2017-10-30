var keressArraTable = document.getElementById('keressArraTable');


var priceMin = document.getElementById('arMezo1');
var priceMax = document.getElementById('arMezo2');
var arButton = document.getElementById("arButton"); 

var keressArraTomb = [];
var keressTipusTomb = [];
var keressAnyagTomb = [];
var keressSzinTomb = [];

var egysegesitett = [];


var agyCheckBox = document.getElementById('agy');
var szekCheckBox = document.getElementById('szek');
var szekrenyCheckBox = document.getElementById('szekreny');
var asztalCheckBox = document.getElementById('asztal');

var faCheckBox = document.getElementById('fa');
var textilCheckBox = document.getElementById('textilia');
var vasCheckBox = document.getElementById('vas');
var muanyagCheckBox = document.getElementById('muanyag');

var feherCheckBox = document.getElementById('feher');
var feketeCheckBox = document.getElementById('fekete');
var termeszetesCheckBox = document.getElementById('termeszetes');


var olcsoRadio = document.getElementById('legolcsobbR');
var dragaRadio = document.getElementById('legdragabbR');
var nepszeruRadio = document.getElementById('legnepszerubbR');

function torol(){
        
        document.getElementById('arMezo1').value = 0;
        document.getElementById('arMezo2').value = 100;
        olcsoRadio.checked = false;
        dragaRadio.checked = false;
        nepszeruRadio.checked = false;
    }

function szuro(){
    keressArra(butorData);
    tipusKivalaszt(butorData);
    anyagKivalaszt(butorData);
    szinKivalaszt(butorData);

    egysegesito(keressArraTomb, keressTipusTomb, keressAnyagTomb, keressSzinTomb);
    arSzerintRendez(egysegesitett);
    print(egysegesitett);
}


function keressArra(data){
    keressArraTomb=[];
    for(i=0; i<data.length; i++){
        if(priceMin.value < data[i].price && priceMax.value > data[i].price){
            
            keressArraTomb.push(data[i]);
        }
    } 
}

function tipusKivalaszt(data){
    
    keressTipusTomb = [];
    
    if(agyCheckBox.checked == false && szekCheckBox.checked == false 
    && szekrenyCheckBox.checked == false && asztalCheckBox.checked == false){
       keressTipusTomb = data;
    }

    if(agyCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].type === "bed"){
                keressTipusTomb.push(data[i]);
            }
        }
    }
    
    if(szekCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].type === "chair"){
        
            keressTipusTomb.push(data[i]);    
            }
        }
    }
    
     if(szekrenyCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].type === "wardrobe"){
                 keressTipusTomb.push(data[i]);
            }
        }
    }
   
    if(asztalCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].type === "table"){
                keressTipusTomb.push(data[i]);
            }
        }
    }
  
}

function anyagKivalaszt(data){
    
    keressAnyagTomb = [];
    
    if(faCheckBox.checked == false && textilCheckBox.checked == false 
    && vasCheckBox.checked == false && muanyagCheckBox.checked == false){
       keressAnyagTomb = data;
    }

    if(faCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].material === "wood"){
                keressAnyagTomb.push(data[i]);
            }
        }
    }
    
    if(textilCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].material === "textil"){
        
            keressAnyagTomb.push(data[i]);    
            }
        }
    }
    
     if(vasCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].material === "iron"){
                 keressAnyagTomb.push(data[i]);
            }
        }
    }
   
    if(muanyagCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].material === "plastic"){
                keressAnyagTomb.push(data[i]);
            }
        }
    }
  
}

function szinKivalaszt(data){
    
    keressSzinTomb = [];
    
    if(feherCheckBox.checked == false && feketeCheckBox.checked == false 
    && termeszetesCheckBox.checked == false){
       keressSzinTomb = data;
    }

    if(feherCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].color === "white"){
                keressSzinTomb.push(data[i]);
            }
        }
    }
    
    if(feketeCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].color === "black"){
        
            keressSzinTomb.push(data[i]);    
            }
        }
    }
    
     if(termeszetesCheckBox.checked == true){
        for(i=0; i<data.length; i++){
            if(data[i].color === "natural"){
                 keressSzinTomb.push(data[i]);
            }
        }
    }  
}

function egysegesito(a,b, c,d){
egysegesitett = [];
    for(var i=0; i<a.length; i++){
        for(var j=0; j<b.length; j++){
            for(var m=0; m<c.length; m++){
                for(var n=0; n<d.length; n++){
                
                    if(a[i].name == b[j].name && a[i].name == c[m].name && a[i].name == d[n].name){
                        egysegesitett.push(a[i]);
                    }
                }
            }
        }
    }
}


function arSzerintRendez(egysegesitett){
  

for(var i = 0;  i < egysegesitett.length; i++ ){
    for(var j = i+1; j< egysegesitett.length; j++){
        if(olcsoRadio.checked == true){
            if(egysegesitett[i][kulcs="price"] > egysegesitett[j][kulcs="price"]){
            var temp = [egysegesitett[i], egysegesitett[j]];
            egysegesitett[i] = temp[1];
            egysegesitett[j] = temp[0];
            }
        }
        if(dragaRadio.checked == true){
            if(egysegesitett[i][kulcs="price"] < egysegesitett[j][kulcs="price"]){
            var temp = [egysegesitett[i], egysegesitett[j]];
            egysegesitett[i] = temp[1];
            egysegesitett[j] = temp[0];
            }
        }  
        if(nepszeruRadio.checked == true){
            if(egysegesitett[i][kulcs="popularity"] > egysegesitett[j][kulcs="popularity"]){
            var temp = [egysegesitett[i], egysegesitett[j]];
            egysegesitett[i] = temp[1];
            egysegesitett[j] = temp[0];
          }
        }
    }   
  }
}


function print(data){
    keressArraTable.innerHTML = "";
    keressArraTable.innerHTML += "<tr><td><b>Név</b></td><td><b>Típus</b></td><td><b>Népszerűség</b></td><td><b>Anyag</b></td><td><b>Méret</b></td><td><b>Ár (Ft)</b></td><td><b>Szín </b></td><td><b>Kép</b></td></tr></b>"
    for(i=0; i< data.length; i++){
        keressArraTable.innerHTML += '<tr><td>' + data[i].name + '</td><td> ' 
                 + data[i].type + '</td><td>'
                 + data[i].popularity + '</td><td>'
                 + data[i].material + '</td><td>'
                 + data[i].width + 'cm x ' +  data[i].depth + ' cm</td><td>'
                 + data[i].price + '</td><td>'
                 + data[i].color + '</td><td> <img src=" '
                 + data[i].img + ' "></td><tr>';
    }
}