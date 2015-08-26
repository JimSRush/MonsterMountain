/*Rotates the sun around the mountain triggering a day/night cycle*/


var cyclemins : float;
var cyclecalc : float;

cyclemins = 1;
cyclecalc = 0.1/cyclemins *-1;

function Update (){
	transform.Rotate(0, 0, cyclecalc, Space.World);
}