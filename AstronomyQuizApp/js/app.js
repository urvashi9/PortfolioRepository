$(document).ready(function(){
	/*
	var questions=[{
		questionNumber:0,
		question:"Which of the following planets would float if you put it in water?",
		options:["Saturn","Venus"],
		answer:0,
		description:"Even though Saturn is the second largest planet in the Solar System, it is the least dense. It is mainly composed of hydrogen and helium and does not have a solid surface, hence it would float if you it in water.",
		backgroundImage:"../Images/Water.jpg"

	},{
		questionNumber:1,
		question:"Which of the following planets does not have any seasons?",
		options:["Jupiter","Venus"],
		answer:1,
		description:"The three major factors that influence the seasons are:\n\ra. Eccentricity of the orbit\n\rb. Axial tilt\n\rc. Atmospheric nature\n\rVenus has an almost circular orbit, so negligible eccentricity means negligible contribution to seasons.  Venus has an axial tilt of around 3 degrees (or 177).  That 3 degrees is about one-eighth the tilt Earth has.  Negligible tilt means negligible contribution to seasons.  And finally, the nature of Venus' atmosphere doesn't really allow variation.  The extremely thick blanket maintains a near constant temperature across the entire planet.\n\rHence, Venus doesn\'t have any seasons.",
		backgroundImage:["../Images/Summer.jpg","../Images/Winter.jpg","../Images/Spring.jpg","../Images/Fall.jpg"]
	},{
		questionNumber:2,
		question:"What is the coldest place in the Universe?",
		options:["The North Pole","The Boomerang Nebula"],
		answer:1,
		description:"Boomerang Nebula is in the constellation of Centaurus, 5000 light-years from Earth. With a temperature of -272C, it is only 1 degree warmer than absolute zero (the lowest limit for all temperatures). Even the -270C background glow from the Big Bang is warmer than this nebula. It is the only object found so far that has a temperature lower than the background radiation. It is bow-tie in shape which appears to have been created by a very fierce 500 000 kilometre-per-hour wind blowing ultracold gas away from the dying central star. The star has been losing as much as one-thousandth of a solar mass of material per year for 1500 years. This is 10-100 times more than in other similar objects. The rapid expansion of the nebula has enabled it to become the coldest known region in the Universe.",
		backgroundImage:"../Images/Cold.jpg"
	},{
		questionNumber:3,
		question:"What is the largest known diamond in the universe?",
		options:["Lucy","Hope Diamond"],
		answer:0,
		description:"Astronomers have discovered the largest known diamond in our galaxy, it’s a massive lump of crystallised diamond called BPM 37093, otherwise known as Lucy after The Beatles’ song Lucy in the Sky with Diamonds. Found 50 light-years away in the constellation of Centaurus, Lucy is about 25,000 miles across, so much larger then planet Earth, and weighs in at a massive 10 billion-trillion-trillion carats.",
		backgroundImage:"../Images/Diamond.png"
	},{
		questionNumber:4,
		question:"Where is our solar system's biggest mountain?",
		options:["Jupiter","Mars"],
		answer:1,
		description:"Olympus Mons on Mars is the tallest mountain on any of the planets of the Solar System. The mountain is a gigantic shield volcano (similar to volcanoes found in the Haiiwain Islands) standing at 26 kilometres tall and sprawling 600 kilometres across. To put this into scale, this makes the mountain almost three times the height of Mount Everest.",
		backgroundImage:"../Images/Mountain.jpg"
	}];

*/

//  global variables

	var totalCorrect=0;
	// var currentQuestion=0;

//  clicking submit button after answering each question

/*	$('.questionsList').on("click","#submit",function(){
		updateQuestion();
		currentQuestion++;
		feedback();
	});
*/

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

//  start the quiz

/*	$('.questionsList').on("click","#start",function(){
		currentQuestion=0;
		totalCorrect=0;
		var newQuestion='<div class="questionsList">'+questions[currentQuestion].question+'</div><br /><span class="answers"><div id="answer_holder"><input type="radio" name="option" class="option" value="0">'+questions[currentQuestion].options[0]+'</div></span><br /><span class="answers"><div id="answer_holder"><input type="radio" name="option" class="option" value="1">'+questions[currentQuestion].options[1]+'</div></span><br /><div id="button_holder"><input type="button" id="submit" value="Submit"></div>';
		$(".questionsList").html(newQuestion);
		$(".feedback_holder").html("");
	});

*/

//  update to new question

/*	function updateQuestion(){
		var ans=$("input[type='radio']:checked").val();
		if(ans==questions[currentQuestion].answer){
			totalCorrect++;
		}
	}

*/

//  feedback appears

/*	function feedback(){
		var explanation='<span class="facts"><div class="feedback_holder">'+questions[currentQuestion].description+'</span></div><div id="button_holder"><input type="button" id="next" value="Next"></div>';
		$('.feedback_holder').html(explanation);
		nextQuestion();
	}

*/

//  next question is displayed

/*	function nextQuestion(){
		if(currentQuestion<5){
			$('.questionsList').remove();
			$('.option input').remove();
			$('.option span').remove();
			$('.feedback_holder').remove();
			var newQuestion='<div class="questionsList">'+questions[currentQuestion].question+'</div><br /><span class="answers"><div id="answer_holder"><input type="radio" name="option" class="option" value="0">'+questions[currentQuestion].options[0]+'</div></span><br /><span class="answers"><div id="answer_holder"><input type="radio" name="option" class="option" value="1">'+questions[currentQuestion].options[1]+'</div></span><br /><div id="button_holder"><input type="button" id="submit" value="Submit"></div>';
			$('.questionList').html(newQuestion);
		}
		else{
			$('.questionsList').remove();
			$('.option input').remove();
			$('.option span').remove();
			$('.feedback_holder').remove();
			$('#restart').show();
			$('#next').css("display","none");
			$('#restart').css("display","inline");
			if(totalCorrect==1){
				var finalScore='<span id="final">You got ' +totalCorrect+ ' question correct!</span>';
				$('.answers').html(finalScore);
			}
			else{
				var finalScore='<span id="final">You got ' +totalCorrect+ ' questions correct!</span>';
				$('.answers').html(finalScore);
			}
		}
	}
*/
});