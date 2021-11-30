/**
*This slideIndex stores index number for List type of varibale "data" 
*Its initial value is 1
*@type integer slideIndex
*/

var slideIndex = 1;
  
/**
*This data stores image file object
*@type {Object[]} data
*/
var data = [
{file:"images/apartmentsSlideShow/apartment_front.png",desc:"The Apartment Front"},
{file:'images/apartmentsSlideShow/apartment_bathroom.png',desc:'The Apartment Bathroom'},{file:'images/apartmentsSlideShow/private_garden.png',desc:'The Private Garden'},{file:'images/apartmentsSlideShow/beach_pool.png',desc:'The Beach Pool'},{file:'images/apartmentsSlideShow/beach_walkway.png',desc:'The Beach Walkway'},{file:'images/apartmentsSlideShow/jetty.png',desc:'The Jetty'},
];

/**
*This execute function showSlides
*/
showSlides(slideIndex);

/**
*This function fulfils change of image
*
*@param {integer} n - an integer type index
*@return by clicking on next or previous, selected image gets shown in slide, description shown in caption area and its 
* thumbnail image gets visible
*/
function plusSlides(n) {
  showSlides(slideIndex += n);
}

/**
*This function fulfils showing the current selelcted image
*
*@param {integer} n - an integer type index
*@return selected image gets shown in slide, description shown in caption area and its 
* thumbnail image gets visible
*/
function currentSlide(n) {
  showSlides(slideIndex = n);
}

/**
*This function fulfils the slide show
*
*@param {integer} n - an integer type index
*@return selected image gets shown in slide, description shown in caption area and its thumbnail image gets visible with the rest thumnail images showing fading effect.
*/
function showSlides(n) {
  var i;
  var imgSelect = document.getElementById("myImg"); 
  var dots = document.getElementsByClassName("demo");
  var captionText = document.getElementById("caption");

  
  if (n > data.length) {slideIndex = 1;}
  if (n < 1) {slideIndex = data.length;}

    
  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
  }
  // The above code is to blur the Thumbnails picture.
  // It is turning active to blank (i.e. "")

  imgSelect.src = data[slideIndex-1].file;
  dots[slideIndex-1].className += " active";
  captionText.innerHTML = data[slideIndex-1].desc;
}
