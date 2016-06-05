$(document).ready(function(){

/*	$( ".text-box" )
  .keyup(function() {
    var value = $( this ).val();
    $( "li" ).text( value );
  })
  .keyup();

document.getElementById("add").onclick=function(){
	var text=document.getElementById("list-item").value;
	var li="<li>" + text + "</li>";
	document.getElementById("list").appendChild(li);
}
*/

// Add Items To The List


$('#item').on("keyup",function(event){
	if(event.keyCode == 13){
		event.preventDefault();
		$('#add').click();
	};
});
$('#add').click(function(){
		var txtbox = document.getElementById('item');
		var txtval = txtbox.value;
		event.preventDefault();

if(!$.trim($('#item').val())) {
			alert('Please enter text to add to the list');
		} else {
			$('<li class="list-items"></li>').appendTo('.list').html('<div class="box"></div><center style="width:80%;margin-left:4%;height:29px"><div class="groceryList"><input type="checkbox" id="check-box">' + txtval + '</input></div><button type"button" id="delete"><i class="fa fa-trash-o"></i></button></center>');

		document.getElementById('item').value = '';
		};
	});

// Checking Items off the list

/* $('#list-items').on("click",function(){
	if ($('input:checked')){
		$('#list-items').html('<strike><li class="list-items"></li></strike>')
	}
})
*/

$('.list').on('click','li',function(){
	$(this).toggleClass('strike');
	$(this).children('.box').toggleClass('checked');
});
$('.list').on('click','#delete',function(e){
	e.preventDefault();
	$(this).parent().remove();
});
$(document).on('click','.remake',function(){
	$('.list').empty();
});
});