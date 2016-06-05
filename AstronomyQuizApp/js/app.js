$(document).ready(function(){
	
//  global variables

	var totalCorrect=0;

//  restart button

	$('#restart').on("click",function(){
		location.reload();
	});

//  start the quiz RETRY!

	$('#start').on('click',function(){
		// alert('Start the quiz?');
		console.log("start button functions");
		$('#start').hide();
		q1Appear();
	});

//  q1Appear function

	function q1Appear(){
		$('.firstQue').fadeIn(100);
		$('#q1').fadeIn(1000);
		$('#button_holder').fadeIn(1000);
		$('body').css('background-image','url(Images/Water.jpg)');
		$('body').css('color','#424242');
		$('#correct').hide();
		$('#incorrect').hide();
		$('#u1').removeClass('unAnswered');
		$('#u1').addClass('currentQuestion');
	}

	function q1Clear(){
		$('.firstQue').hide();
		$('#q1').hide();
		$('#u1').removeClass('currentQuestion');
		$('#u1').addClass('rightAnswer');
		$('.ans').removeClass('selectedAnswer');
	}


	function q2Appear(){
		$('#fact1').hide();
		$('#next_button_holder').hide();
		$('.secondQue').fadeIn(100);
		$('#q2').fadeIn(1000);
		$('#button_holder').fadeIn(1000);
		$('body').css('background-image','url(Images/Summer.jpg)');
		$('body').css('color','#ff3d00');
		$('#correct').hide();
		$('#incorrect').hide();
		$('#u2').removeClass('unAnswered');
		$('#u2').addClass('currentQuestion');
	}

	function q2Clear(){
		$('.secondQue').hide();
		$('#q2').hide();
		$('#u2').removeClass('currentQuestion');
		$('#u2').addClass('rightAnswer');
		$('.ans').removeClass('selectedAnswer');
	}

	function q3Appear(){
		$('#fact2').hide();
		$('#next_button_holder').hide();
		$('.thirdQue').fadeIn(100);
		$('#q3').fadeIn(1000);
		$('#button_holder').fadeIn(1000);
		$('body').css('background-image','url(Images/Cold.jpg)');
		$('body').css('color','black');
		$('#correct').hide();
		$('#incorrect').hide();
		$('#u3').removeClass('unAnswered');
		$('#u3').addClass('currentQuestion');
	}

	function q3Clear(){
		$('.thirdQue').hide();
		$('#q3').hide();
		$('#u3').removeClass('currentQuestion');
		$('#u3').addClass('rightAnswer');
		$('.ans').removeClass('selectedAnswer');
	}

	function q4Appear(){
		$('#fact3').hide();
		$('#next_button_holder').hide();
		$('.fourthQue').fadeIn(100);
		$('#q4').fadeIn(1000);
		$('#button_holder').fadeIn(1000);
		$('body').css('background-image','url(Images/Diamonds.jpg)');
		$('body').css('color','#1a237e');
		$('#correct').hide();
		$('#incorrect').hide();
		$('#u4').removeClass('unAnswered');
		$('#u4').addClass('currentQuestion');
	}

	function q4Clear(){
		$('.fourthQue').hide();
		$('#q4').hide();
		$('#u4').removeClass('currentQuestion');
		$('#u4').addClass('rightAnswer');
		$('.ans').removeClass('selectedAnswer');
	}

	function q5Appear(){
		$('#fact4').hide();
		$('#next_button_holder').hide();
		$('.fifthQue').fadeIn(100);
		$('#q5').fadeIn(1000);
		$('#button_holder').fadeIn(1000);
		$('body').css('background-image','url(Images/Mountain.jpg)');
		$('body').css('color','white');
		$('#correct').hide();
		$('#incorrect').hide();
		$('#u5').removeClass('unAnswered');
		$('#u5').addClass('currentQuestion');
	}

	function q5Clear(){
		$('.fifthQue').hide();
		$('#q5').hide();
		$('#u5').removeClass('currentQuestion');
		$('#u5').addClass('rightAnswer');
		$('.ans').removeClass('selectedAnswer');
	}

	function checkAnswer(question,answer){
		if((question=="q1") && (answer=="Saturn")){
			q1Clear();
			$('#correct').css({'display':'inline-block'});
			$('#fact1').show();
			$('#u1').addClass('rightAnswer');
		}
		else if((question=="q1") && (answer!="Saturn")){
			q1Clear();
			$('#incorrect').show();
			$('#fact1').show();
			$('#u1').addClass('wrongAnswer');
		}
		else if((question=="q2") && (answer=="Venus")){
			q2Clear();
			$('#correct').show();
			$('#correct').css('font-size','1.7rem');
			$('#fact2').show();
			$('#fact2').css('font-size','1.7rem');
			$('#u2').addClass('rightAnswer');
		}
		else if((question=="q2") && (answer!="Venus")){
			q2Clear();
			$('#incorrect').show();
			$('#fact2').show();
			$('#fact2').css('font-size','1.7rem');
			$('#incorrect').css('font-size','1.7rem');
			$('#u2').addClass('wrongAnswer');
		}
		else if((question=="q3") && (answer=="The Boomerang Nebula")){
			q3Clear();
			$('#correct').show();
			$('#fact3').show();
			$('#fact3').css('font-size','1.7rem');
			$('#correct').css('font-size','1.7rem');
			$('#u3').addClass('rightAnswer');
		}
		else if((question=="q3") && (answer!="The Boomerang Nebula")){
			q3Clear();
			$('#incorrect').show();
			$('#fact3').show();
			$('#fact3').css('font-size','1.7rem');
			$('#incorrect').css('font-size','1.7rem');
			$('#u3').addClass('wrongAnswer');
		}
		else if((question=="q4") && (answer=="Lucy")){
			q4Clear();
			$('#correct').show();
			$('#fact4').show();
			$('#correct').css('font-size','1.7rem');
			$('#fact4').css('font-size','1.7rem');
			$('#u4').addClass('rightAnswer');
		}
		else if((question=="q4") && (answer!="Lucy")){
			q4Clear();
			$('#incorrect').show();
			$('#fact4').show();
			$('#incorrect').css('font-size','1.7rem');
			$('#fact4').css('font-size','1.7rem');
			$('#u4').addClass('wrongAnswer');
		}
		else if((question=="q5") && (answer=="Mars")){
			q5Clear();
			$('#correct').show();
			$('#fact5').show();
			$('#fact5').css('font-size','1.7rem');
			$('#correct').css('font-size','1.7rem');
			$('#u5').addClass('rightAnswer');
		}
		else if((question=="q5") && (answer!="Mars")){
			q5Clear();
			$('#incorrect').show();
			$('#fact5').show();
			$('#fact5').css('font-size','1.7rem');
			$('#incorrect').css('font-size','1.7rem');
			$('#u5').addClass('wrongAnswer');
		}
	}


//  clicking submit button

	$('#submit').on('click',function(){
	    // alert('Submit button pressed');
		console.dir($('.selectedAnswer')[0]);
		var questionNumber = $('.selectedAnswer')[0].parentElement.id;
		var questionAnswer = $('.selectedAnswer')[0].getAttribute("name");
		checkAnswer(questionNumber, questionAnswer);
	    $('#button_holder').hide();
	    $('#next_button_holder').show();
	});


	$('.ans').on('click',function(){
		console.dir(this);
		$('.ans').removeClass('selectedAnswer');
		$(this).addClass('selectedAnswer');
	});

	$('#next_button_holder').on('click',function(){
		// alert('Next button pressed');
		var message="You got " + (5-$('.wrongAnswer').length) + " out 5 quetions correct!";

		$('#correct').hide();
		$('#incorrect').hide();
		if($('.unAnswered').length==4){
			q2Appear();
		}
		else if($('.unAnswered').length==3){
			q3Appear();
		}
		else if($('.unAnswered').length==2){
			q4Appear();
		}
		else if($('.unAnswered').length==1){
			q5Appear();
		}
		else{
			$('body').css('background-image','url(Images/Universe.jpg)');
			$('.finalResult').append(message);
			$('#restart').show();
			$('#fact5').hide();
			$('#next_button_holder').hide();
		}
	});

});