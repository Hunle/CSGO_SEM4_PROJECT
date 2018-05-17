var theTotal = 0;
$('button').click(function(){
   theTotal = Number(theTotal) + Number($(this).val());
    $('.total').text("Total: "+theTotal);        
});

$('.total').text("Total: "+theTotal);        

