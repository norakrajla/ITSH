var sum = [];

function air() {
	
		var price = [200000,180000,170000,160000];

		var value = document.getElementById('selair').value;
		
		if (value == "air1") {
			value = price[0];
		 }

		 if (value == "air2") {
		 	value = price[1];
		 }	

		 if (value == "air3") {
		 	value = price[2];
		 }

		 if (value == "air4") {
		 	value = price[3];
		 }	 	
		 	
		 	
		
		var valueTextBox = document.getElementById('airspan');

		valueTextBox.innerHTML =  value + " Ft";

		sum.push(value);

}
 
function hotel(){

	
	var csillag = document.getElementById('selhotel').value;
	var roomnumber = document.getElementById('selbed').value;
	var reggeli = document.getElementById('reggeli').checked;
	var night = document.getElementById('night').value;

	var star1 = [15000,20000,25000];
	var star3 = [40000,50000,65000];
	var star4 = [70000,85000,100000];
	var star5 = [135000,140000,200000];

		 if (csillag == "hotel2" && roomnumber=="bed1" && reggeli==true) {
			value = star1[0]+1000;
		 

		 }
		 if (csillag == "hotel2" && roomnumber=="bed2" && reggeli==true) {
			value = star1[1]+1000;
		 

		 }
		 if (csillag == "hotel2" && roomnumber=="bed3" && reggeli==true) {
			value = star1[2]+1000;
		 

		 }

		 if (csillag == "hotel2" && roomnumber=="bed1" && reggeli==false) {
			value = star1[0];
		 

		 }
		 if (csillag == "hotel2" && roomnumber=="bed2" && reggeli==false) {
			value = star1[1];
		 

		 }
		 if (csillag == "hotel2" && roomnumber=="bed3" && reggeli==false) {
			value = star1[2];
		 

		 }
		 if (csillag == "hotel3" && roomnumber=="bed1" && reggeli==true) {
			value = star3[0]+2000;
		 

		 }
		 if (csillag == "hotel3" && roomnumber=="bed2" && reggeli==true) {
			value = star3[1]+2000;
		 

		 }
		 if (csillag == "hotel3" && roomnumber=="bed3" && reggeli==true) {
			value = star3[2]+2000;
		 

		 }

		 if (csillag == "hotel3" && roomnumber=="bed1" && reggeli==false) {
			value = star3[0];
		 

		 }
		 if (csillag == "hotel3" && roomnumber=="bed2" && reggeli==false) {
			value = star3[1];
		 

		 }
		 if (csillag == "hotel3" && roomnumber=="bed3" && reggeli==false) {
			value = star3[2];
		 

		 }if (csillag == "hotel4" && roomnumber=="bed1" && reggeli==true) {
			value = star4[0]+2000;
		 

		 }
		 if (csillag == "hotel4" && roomnumber=="bed2" && reggeli==true) {
			value = star4[1]+2000;
		 

		 }
		 if (csillag == "hotel4" && roomnumber=="bed3" && reggeli==true) {
			value = star4[2]+2000;
		 

		 }

		 if (csillag == "hotel4" && roomnumber=="bed1" && reggeli==false) {
			value = star4[0];
		 

		 }
		 if (csillag == "hotel4" && roomnumber=="bed2" && reggeli==false) {
			value = star4[1];
		 

		 }
		 if (csillag == "hotel4" && roomnumber=="bed3" && reggeli==false) {
			value = star4[2];
		 

		 }if (csillag == "hotel5" && roomnumber=="bed1" && reggeli==true) {
			value = star5[0]+4000;
		 

		 }
		 if (csillag == "hotel5" && roomnumber=="bed2" && reggeli==true) {
			value = star5[1]+4000;
		 

		 }
		 if (csillag == "hotel5" && roomnumber=="bed3" && reggeli==true) {
			value = star5[2]+4000;
		 

		 }

		 if (csillag == "hotel5" && roomnumber=="bed1" && reggeli==false) {
			value = star5[0];
		 

		 }
		 if (csillag == "hotel5" && roomnumber=="bed2" && reggeli==false) {
			value = star5[1];
		 

		 }
		 if (csillag == "hotel5" && roomnumber=="bed3" && reggeli==false) {
			value = star5[2];
		 

		 }




		var valueTextBox = document.getElementById('airhotel');

		valueTextBox.innerHTML =  value * night + " Ft";

		sum.push(parseFloat(value));
}
function trafic() {
	
		var price =  document.getElementById('trafic2').value;
		
		
		 var value = price*70000;
		 	
		
		var valueTextBox = document.getElementById('trafic1');

		valueTextBox.innerHTML =  value + " Ft";

		sum.push(parseFloat(value));
}





function food() {
	
		var price = [2000,3500,10000];

		var piece1 = document.getElementById('food1').value;
		var piece2 = document.getElementById('food2').value;
		var piece3 = document.getElementById('food3').value;
		
		 var value = piece1* price[0]+piece2* price[1]+piece3* price[2];
		 	
		 	
		
		var valueTextBox = document.getElementById('food');

		valueTextBox.innerHTML =  value + " Ft";

		sum.push(parseFloat(value));
}
function summa(){

	
	var hund = parseInt(sum[0]) + parseInt(sum[1]) + parseInt(sum[2]) + parseInt(sum[3]); 
	var hund2 = document.getElementById('sum');
	hund2.innerHTML = hund +" Ft"

}
