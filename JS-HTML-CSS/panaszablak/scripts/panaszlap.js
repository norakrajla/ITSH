var lastComplainId = -1;
var numberOfComplains = 0;
var inputFiles = {};

var inputComplainBlock = document.querySelector('#inputComplainBlock');
var outputComplainBlock = document.querySelector('#complainOutput');

// Költség számláló
function koltsegSzamlalo(){
    var outputElem = document.querySelector('#koltsegSzamlalo');
    var koltseg = 10 + (numberOfComplains - 1) * 2;
    outputElem.innerHTML = '<div id="koltsegSzamlalo">A panasz benyújtásának költsége: <br> ' + koltseg + ' zseton </div>';
    outputElem.classList.remove("elrejt");
}

// új panaszblokk hozzáadása
function addNewComplain(){
    if (checkEmptyComplainFields() && checkEmptyPersonalFields()){
        lastComplainId++;
        numberOfComplains++;
        var newChild = document.createElement('div');
        newChild.id = 'complain' + lastComplainId;
        newChild.innerHTML = generateComplainHTML();
        inputComplainBlock.appendChild(newChild);
        outputComplainData();
        displayHideFirstButton();
        koltsegSzamlalo();
        charLeft(lastComplainId);        
    }
    else{
        alert('Új panasz hozzáadásához minden adatmező kitöltése szükséges!');
    }
}

// bemeneti panaszblokk HTML részének generálása
function generateComplainHTML(){
    return '<button onclick="removeActualComplain(\'complain' + lastComplainId + '\')" class="panaszTorles btn btn-danger btn-lg btn-block">Panasz törlése</button><br>\n'+
            '<label for="szomszedPozicio' + lastComplainId + '">Melyik szomszéd?</label><br>\n' +
            '<select id="szomszedPozicio' + lastComplainId + '" name="szomszedPozicio" onchange="toggleOtherPosition(\'' + lastComplainId + '\')">' + getPositionOptions() + '</select><br>' + 
            '<input type="text" id="szomszedPozicioEgyeb' + lastComplainId + '" class="form-control hidden" name="szomszedPozicioEgyeb">' +
            '<p><b>Leggyakoribb panasz típusok:</b></p>' +
            '<div class="tipikus">' +
            '<input type="checkbox" name="panaszTipus" id="1-' + lastComplainId + '" value="Agresszív / zavaró házi kedvencek tartása">'+
            '<label for="1-' + lastComplainId + '">1. Agresszív / zavaró házi kedvencek tartása</label><img src="img/kutya.jpg">\n <br>' + 

            '<input type="checkbox" name="panaszTipus" id="2-' + lastComplainId + '" value="Közterületen, közös lakótérben (folyosó, lépcsőház) való szemetelés.">' +
            '<label for="2-' + lastComplainId + '"> 2. Közterületen, közös lakótérben (folyosó, lépcsőház) való szemetelés.</label><img src="img/szemetel.png">\n <br>' +

            '<input type="checkbox" name="panaszTipus" id="3-' + lastComplainId + '" value="Illegális baromfitartás, engedély nélküli állattenyésztés.">' +
            '<label for="3-' + lastComplainId + '">3. Illegális baromfitartás, engedély nélküli állattenyésztés.</label><img src="img/allattenyesztes.jpg">\n <br>' +

            '<input type="checkbox" name="panaszTipus" id="4-' + lastComplainId + '" value="Magánterületen történő parkolás.">' +
            '<label for="4-' + lastComplainId + '">4. Magánterületen történő parkolás.</label><img src="img/parkolas.jpg">\n <br>' +

            '<input type="checkbox" name="panaszTipus" id="5-' + lastComplainId + '" value="Illegális tűzrakás, szemétégetés. Huzamos idejű légszennyezés.">' + 
            '<label for="5-' + lastComplainId + '">5. llegális tűzrakás, szemétégetés. Huzamos idejű légszennyezés.</label><img src="img/tuz.jpg">\n <br>' +

            '<input type="checkbox" name="panaszTipus" id="6-' + lastComplainId + '" value="Szabálytalan felújítási munkálatok végzése.">' +
            '<label for="6-' + lastComplainId + '">6. Szabálytalan felújítási munkálatok végzése.</label><img src="img/szerel.jpg">\n <br></div>' +

            
            '<label for="egyebPanaszTipus">Egyéb: </label><input type="text" name="egyebPanaszTipus" id="egyebPanaszTipus" class="form-control">\n <br><br>' + 
            '<p><b>Panasz leírása</b></p>' +
            '<textarea name="panaszSzoveg" id="panaszSzoveg' + lastComplainId + '" cols="50" class="form-control" rows="10"  maxlength="200" onkeydown="charLeft(\'' + lastComplainId + '\')" onkeyup="charLeft(\'' + lastComplainId + '\')"></textarea><br>' + 
            '<p class="hide">Még <span id="charactersLeft' + lastComplainId + '"></span> karakter maradt.</p>' + 
            '<input type="file" id="kepInput' + lastComplainId + '" onchange="fileInputChange(\'' + lastComplainId + '\')"><br>';
}

// a megadott panasz bemeneti blokk törlése
function removeActualComplain(complainName){
    numberOfComplains--;
    var childToRemove = document.querySelector('#' + complainName);
    inputComplainBlock.removeChild(childToRemove);    
    outputComplainData();
    displayHideFirstButton();
    koltsegSzamlalo();
}

// ki-be kapcsolja az első panaszmező törlő gombjának láthatóságát
function displayHideFirstButton(){
     var btn = document.querySelector('.panaszTorles');
     if (numberOfComplains == 1) {
        btn.style.display = 'none'
     } else {
        btn.style.display = 'inline'
     };
 }

// ellenőrzi, hogy van-e üres mező a személyes adatok bemeneti részén
function checkEmptyPersonalFields(){
    var data = getPersonalData();
    for (var k in data){
        if (data[k] === ''){
            return false;
        }
    }
    return true;
}

// ellenőrzi, hogy van-e üres mező a panaszok bemeneti részén
function checkEmptyComplainFields(){
    var data = getComplainData();    
    for (var i = 0 ; i < data.length; i++){
        for (var k in data[i]){
            if (data[i][k] === ''){                
                return false;
            }
        }
    }
    return true;
}

// a lakóingatlan típus alapján generál a szomszéd pozíciójára javasolt választásokat, és string html adatot ad vissza
function getPositionOptions(){
    var tanya = ['a dűlőút túlvégén', '3 km-re keletre', 'az, ahol lejövök a köves útról', 'az előző tulajdonos'];
    var haz = ['jobb oldali szomszéd', 'bal oldali szomszéd', 'hátsó szomszéd', 'szembe szomszéd'];
    var lakas = ['alsó szomszéd', 'felső szomszéd', 'jobb oldali szomszéd', 'bal oldali szomszéd', 'szembe szomszéd'];

    var propertyType = getPersonalData().ingatlanTipus;
    switch (propertyType) {
        case 'tanya':
            var positions = tanya;
            break;
        case 'családi ház':
        case 'sorház':
            var positions = haz;
            break;
        case 'társasházi lakás':
        case 'panel lakás':
            var positions = lakas;
            break;
            
    }
    

    var result = '<option value="">Válassz</option>';
    for (var i = 0; i < positions.length; i++) {
        result += '<option>' + positions[i] + '</option>';
    }
    result += '<option value="other">Egyéb</option>';

    return result;
}

// a bemeneti panaszblokkon a szomszéd helye szakaszában kapcsolja ki-be az egyéb szöveges bemeneti mezőt
function toggleOtherPosition(complainID){
    var select = document.querySelector('#szomszedPozicio' + complainID);
    var input = document.querySelector('#szomszedPozicioEgyeb' + complainID);
    if (select.value === 'other'){
        input.classList.remove('hidden');
    }
    else {
        input.classList.add('hidden');
    }
}

// indítja a személyes adatok blokk frissítését az önellenőrzés részen
function outputPersonalData(){
    var jsonPersonalData = JSON.stringify(getPersonalData(), null, 4);
    refreshOutputData(jsonPersonalData);
}

// beolvassa a személyes adatokat és egy objektumként adja vissza
function getPersonalData(){
    var personal = document.querySelector('#personal');
    var fullName = personal.querySelector('#fullName').value;
    var personalAddress = personal.querySelector('#personalAddress').value;
    var hrsz = personal.querySelector('#hrsz').value;
    var phoneNumber = personal.querySelector('#phoneNumber').value;

    var osszesTelepulesTipus = personal.querySelectorAll('[name="telepulesTipus"]');
    var checkedTelepulesTipus;

    for(i=0; i < osszesTelepulesTipus.length; i++){       
        if( osszesTelepulesTipus[i].checked){
            checkedTelepulesTipus = osszesTelepulesTipus[i];
        }
    }

    var telepulesTipus = checkedTelepulesTipus.value;
    var ingatlanTipus = personal.querySelector('#ingatlanTipus').value;
    var personalDataObject = {
        'fullName':  fullName,
        'personalAddress': personalAddress,
        'hrsz': hrsz,
        'phoneNumber': phoneNumber,
        'telepulesTipus': telepulesTipus,
        'ingatlanTipus': ingatlanTipus
    }
    return personalDataObject;
}

//frissíti a személyes adatokat a bemenő JSON adat alapján
function refreshOutputData(rawData) {
    personalDataObject = JSON.parse(rawData);
    var personalOutput = document.querySelector('#personalOutput');
    personalOutput.querySelector('#fullNameOutput').innerHTML = personalDataObject.fullName;
    personalOutput.querySelector('#addressOutput').innerHTML = personalDataObject.personalAddress;
    personalOutput.querySelector('#hrszOutput').innerHTML = personalDataObject.hrsz;
    personalOutput.querySelector('#phoneNumberOutput').innerHTML = personalDataObject.phoneNumber;
    personalOutput.querySelector('#telepulesTipusOutput').innerHTML = personalDataObject.telepulesTipus;
    personalOutput.querySelector('#ingatlanTipusOutput').innerHTML = personalDataObject.ingatlanTipus;
}

// indítja az önellenőrzés rész panaszok blokkjának frissítését
function outputComplainData(){
    var jsonComplainsData = JSON.stringify(getComplainData(), null, 4);
    refreshOutputComplainData(jsonComplainsData);
}

// beolvassa a bevitt panaszok adatait, és ennek adattömbjét adja vissza
function getComplainData() {
    var complains = document.querySelector('#inputComplainBlock').children;
    var complainsArray = [];
    for (var i = 0; i < complains.length; i++) {
        var panaszTipus = [];
        var panaszTipusLista = complains[i].querySelectorAll('[name="panaszTipus"]');
        for (var j = 0; j < panaszTipusLista.length; j++){
            if (panaszTipusLista[j].checked){
                panaszTipus.push(panaszTipusLista[j].value);
            }
        }
        if (complains[i].querySelector('#egyebPanaszTipus').value !== ''){
            panaszTipus.push(complains[i].querySelector('#egyebPanaszTipus').value);
        }
        
        var szomszedPozicio = complains[i].querySelector('[name="szomszedPozicio"]').value;
        if (szomszedPozicio === 'other'){
            szomszedPozicio = complains[i].querySelector('[name="szomszedPozicioEgyeb"]').value
        }

        var fileInputField = complains[i].querySelector('[type="file"]');
        if (fileInputField.files.length > 0){
            var fileName = fileInputField.files[0].name;
        }
        else {
            var fileName = 'nincs';
        }       

        var complain = {
            'szomszedPozicio': szomszedPozicio,
            'panaszTipus': panaszTipus.join('<br> '),
            'panaszSzoveg': complains[i].querySelector('[name="panaszSzoveg"]').value,
            'panaszKep': fileName
        };
        complainsArray.push(complain);
    }
    return complainsArray;
}

// frissíti az önellenőrzés blokk panaszblokkját (a JSON stringify-parse miatt alibiből külön föggvény)
function refreshOutputComplainData(rawData){
    complainsDataArray = JSON.parse(rawData);
    var complainsOutput = document.querySelector('#complainOutput');
    complainsOutput.innerHTML = createComplainOutputHtml(complainsDataArray);
    createOutputPictures();
}

// a panaszblokkok html string kimenetét állítja elő
function createComplainOutputHtml(complainsDataArray){
    var result = '<h2>Panaszok</h2>';
    for (var i =0; i < complainsDataArray.length; i++){
        var bonusz = '';
        if(i % 3 == 1){
            bonusz = ' lapdobas';
        }
        result += '<div class="panaszEgyseg' + bonusz + '">\n <h3>' + (i+1) + '. panasz</h3><div class="panaszFelirat">Melyik szomszéd?</div><div class="szomszedPozicioOutput">' + complainsDataArray[i].szomszedPozicio + '</div>\n' +
                    '<div class="panaszFelirat">Leggyakoribb panasz típusok:</div><div class="panaszTipusOutput">' + complainsDataArray[i].panaszTipus + '</div>\n<div class="panaszFelirat">Panasz leírása:</div><div class="panaszSzovegOutput">' +
                     complainsDataArray[i].panaszSzoveg + '</div>\n <br>' + 
                     '<div class="panaszKepOutput" data-kep="' + complainsDataArray[i].panaszKep + '"></div></div>';
    }

    return result;
}

// az önellenőrzés oldalon megjeleníti a bevitt képeket (panaszonként 1 kép jelenik meg, amelyiket utoljára választották)
function createOutputPictures(){
    var pictureOutputs = outputComplainBlock.querySelectorAll('.panaszKepOutput');
    for (var i = 0; i < pictureOutputs.length; i++){
        var fileName = pictureOutputs[i].dataset.kep;                
        if (fileName !== 'nincs'){
            var file = inputFiles[fileName];
            var output = pictureOutputs[i];
            viewPictures(file, output);            
        }
    }
}

// a megadott helyen belül létrehozza a fájl alapján a képet
function viewPictures(file, output){
    var reader = new FileReader();

    reader.addEventListener("load", function () {
        var image = document.createElement('img');      
        image.classList.add('panaszKep');
        image.src = reader.result;
        output.appendChild( image );       
    }); 

    reader.readAsDataURL(file);
}

// A beállított lakóhelytípus alapján elrejti a nem passzoló lakóingatlantípusokat
function changePropertyType(){
    var propertyMatrix = {
        'Budapest': [true, false, true, true, true, true],
        'Nagyváros': [true, false, true, true, true, true],
        'Kisváros': [true, false, true, true, true, true],
        'Község': [true, true, true, true, true, false],
        'Kisfalu': [true, true, true, true, false, false],
        'Aprófalu': [true, true, true, true, false, false],
        'Törpefalu': [true, true, true, false, false, false],
        'Tanyavilág': [true, true, true, false, false, false]
    }
    var settlementType = getPersonalData().telepulesTipus;
    var lathatosag = [true, true, true, true, true, true];
    for (var k in propertyMatrix){        
        if (k === settlementType){
            var lathatosag = propertyMatrix[k];
        } 
    }
    var options = document.querySelector('#ingatlanTipus').children;
    for (var i = 0; i < options.length; i++){
        options[i].classList.toggle('hidden', !lathatosag[i] );
    }
}


// számolja a bemeneti panaszszövegek karakterszámát
function charLeft(complainID){
    var textarea = document.querySelector('#panaszSzoveg' + complainID);
    var outputSpan = document.querySelector('#charactersLeft' + complainID);
    var maxChar = textarea.maxLength;
    var charactersLeft = maxChar - textarea.value.length;    
    outputSpan.innerHTML = charactersLeft;
}

function fileInputChange(complainID){
    var fileInputField = inputComplainBlock.querySelector('#kepInput' + complainID);
    var fileName = fileInputField.files[0].name;
    inputFiles[fileName] = fileInputField.files[0];
}
function finishComplaints(){
    if(checkEmptyComplainFields() && checkEmptyPersonalFields() && numberOfComplains >0){
        window.print();
    }else{
        alert("Minden mező kitöltése szükséges a nyomtatáshoz!");
    }
}
function showEszement(){
    var jsonPersonalData = JSON.stringify(getPersonalData(), null, 4);
    var jsonComplainsData = JSON.stringify(getComplainData(), null, 4);

    var jsonPersonal = document.getElementById('jsonPersonal'); 
    jsonPersonal.innerHTML =  jsonPersonalData;
   var jsonComplain =  document.getElementById('jsonComplain');
      jsonComplain.innerHTML = jsonComplainsData;

 jsonPersonal.classList.toggle('elrejt');
 jsonComplain.classList.toggle('elrejt');
    

}