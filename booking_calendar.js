/**This includes variables cal that has multiple properties
*and function that draws calendar, create an eventt dialogue
*that includes daily cost,fulfils saving new event and deleting 
*existing event in event dialogue, record total cost.
*/
var cal = {
  // (A) PROPERTIES
  mName : ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"], // Month Names
  data : null, // Events for the selected period
  sDay : 0, // Current selected day
  sMth : 0, // Current selected month
  sYear : 0, // Current selected year
  sMon : false, // Week start on Monday?

  // (B) DRAW CALENDAR FOR SELECTED MONTH
  list : function () {
    // (B1) BASIC CALCULATIONS - DAYS IN MONTH, START + END DAY
    // Note - Jan is 0 & Dec is 11 in JS.
    // Note - Sun is 0 & Sat is 6
    cal.sMth = parseInt(document.getElementById("cal-mth").value); // selected month
    cal.sYear = parseInt(document.getElementById("cal-yr").value); // selected year
    var daysInMth = new Date(cal.sYear, cal.sMth+1, 0).getDate(), // number of days in selected month
        startDay = new Date(cal.sYear, cal.sMth, 1).getDay(), // first day of the month
        endDay = new Date(cal.sYear, cal.sMth, daysInMth).getDay(); // last day of the month

    // (B2) LOAD DATA FROM LOCALSTORAGE
    cal.data = localStorage.getItem("cal-" + cal.sMth + "-" + cal.sYear);
    if (cal.data==null) {
      localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, "{}");
      cal.data = {};
    } else {
      cal.data = JSON.parse(cal.data);
    }

    // (B3) DRAWING CALCULATIONS
    // Determine the number of blank squares before start of month
    var squares = [];
    if (cal.sMon && startDay != 1) {
      var blanks = startDay==0 ? 7 : startDay ;
      for (var i=1; i<blanks; i++) { squares.push("b"); }
    }
    if (!cal.sMon && startDay != 0) {
      for (var i=0; i<startDay; i++) { squares.push("b"); }
    }

    // Populate the days of the month
    for (var i=1; i<=daysInMth; i++) { squares.push(i); }

    // Determine the number of blank squares after end of month
    if (cal.sMon && endDay != 0) {
      var blanks = endDay==6 ? 1 : 7-endDay;
      for (var i=0; i<blanks; i++) { squares.push("b"); }
    }
    if (!cal.sMon && endDay != 6) {
      var blanks = endDay==0 ? 6 : 6-endDay;
      for (var i=0; i<blanks; i++) { squares.push("b"); }
    }

    // (B4) DRAW HTML CALENDAR
    // Container
    var container = document.getElementById("cal-container"),
        cTable = document.createElement("table");
    cTable.id = "calendar";
    container.innerHTML = "";
    container.appendChild(cTable);

    // First row - Day names
    var cRow = document.createElement("tr"),
        cCell = null,
        days = ["Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"];
    if (cal.sMon) { days.push(days.shift()); }
    for (var d of days) {
      cCell = document.createElement("td");
      cCell.innerHTML = d;
      cRow.appendChild(cCell);
    }
    cRow.classList.add("head");
    cTable.appendChild(cRow);

    // Days in Month
    var total = squares.length;
    cRow = document.createElement("tr");
    cRow.classList.add("day");
    for (var i=0; i<total; i++) {
      cCell = document.createElement("td");
      if (squares[i]=="b") { cCell.classList.add("blank"); }
      else {
        cCell.innerHTML = "<div class='dd'>"+squares[i]+"</div>";
        if (cal.data[squares[i]]) {
          cCell.innerHTML += "<div class='evt'>" + cal.data[squares[i]] + "</div>";
        }
        cCell.addEventListener("click", function(){
          cal.show(this);
        });
      }
      cRow.appendChild(cCell);
      if (i!=0 && (i+1)%7==0) {
        cTable.appendChild(cRow);
        cRow = document.createElement("tr");
        cRow.classList.add("day");
      }
    }

    // (B5) REMOVE ANY PREVIOUS ADD/EDIT EVENT DOCKET
    cal.close();
   /* Add New Code */
       document.getElementById("total-cost").innerText = localStorage.getItem("total-cost");
   /* End of New Code */
  },

  // (C) SHOW EDIT EVENT DOCKET FOR SELECTED DAY
  show : function (el) {
    // (C1) FETCH EXISTING DATA
    cal.sDay = el.getElementsByClassName("dd")[0].innerHTML;
	dayNumb = parseInt(cal.sDay); // New Code reason dates will be compared to decide the price range the date falls into see line 116
    // (C2) DRAW EVENT FORM
	   var cost = 0; // New Code
	   
	 /* Add New Code */
	// Calculation for House Sales
    
        if (cal.sMth >=5 && cal.sMth<=7)
        {
            var cost = Number(200).toLocaleString('en');
        }
        else if (cal.sMth >=8 && cal.sMth<=10)
        {
            var cost = Number(220).toLocaleString('en');
        }
        else if (cal.sMth == 11 && dayNumb >= 1 && dayNumb <= 18)
        {
            var cost = Number(220).toLocaleString('en');
        }
        else if(cal.sMth == 11 && dayNumb >= 19)
        {
            var cost = Number(250).toLocaleString('en');
        }    
        else if(cal.sMth == 0)
        {
            var cost = Number(250).toLocaleString('en');
        } 
        if (cal.sMth >=1 && cal.sMth<=4)
        {
            var cost = Number(220).toLocaleString('en');
        }
		// if (cal.sMth == 0 && dayNumb >= 5 && dayNumb <= 15)
		// {
		   // var cost = 450000;
		// }
		// else if (cal.sMth == 11 || cal.sMth == 0)
		// {
		   // cost = 700000;
		// }
		// else if (cal.sMth == 10)
		// {
		   // var cost = 600000;
		// }
		// else if (cal.sMth >= 1 && cal.sMth <= 9)
		// {
		   // var cost = 500000;
		// }

   /* End of New Code */	
    var tForm = "<h1>" + (cal.data[cal.sDay] ? "EDIT" : "ADD") + " EVENT</h1>";
    tForm += "<div id='evt-date'>" + cal.sDay + " " + cal.mName[cal.sMth] + " " + cal.sYear + "</div>";
//    tForm += "<textarea id='evt-details' required>" + (cal.data[cal.sDay] ? cal.data[cal.sDay] : "") + "</textarea>";
    tForm += "<label>Cost = </label>"; // New Code
    tForm += "<label id='evt-details' required>"  + cost + "</label><br />";

	tForm += "<input type='button' value='Close' onclick='cal.close()'/>";
    tForm += "<input type='button' value='Delete' onclick='cal.del()'/>";
    tForm += "<input type='submit' value='Save'/>";

    // (C3) ATTACH EVENT FORM
    var eForm = document.createElement("form");
    eForm.addEventListener("submit", cal.save);
    eForm.innerHTML = tForm;
    var container = document.getElementById("cal-event");
    container.innerHTML = "";
    container.appendChild(eForm);
  },

  // (D) CLOSE EVENT DOCKET
  close : function () {
    document.getElementById("cal-event").innerHTML = "";
  },

  // (E) SAVE EVENT
  save : function (evt) {
    evt.stopPropagation();
    evt.preventDefault();
    cal.data[cal.sDay] = document.getElementById("evt-details").innerText;
    localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, JSON.stringify(cal.data));
     /* Add New Code */
    localStorage.setItem("total-cost",parseInt(localStorage.getItem("total-cost")) + parseInt(cal.data[cal.sDay])); 
    /* End of New Code */
    cal.list();
  },

  // (F) DELETE EVENT FOR SELECTED DATE
  del : function () {
    if (confirm("Remove event?")) {
	  /* Add New Code */
          localStorage.setItem("total-cost",parseInt(localStorage.getItem("total-cost")) - parseInt(cal.data[cal.sDay])); 
      /* End of New Code */
		
      delete cal.data[cal.sDay];
      localStorage.setItem("cal-" + cal.sMth + "-" + cal.sYear, JSON.stringify(cal.data));
      cal.list();
    }
  }
};

// (G) INIT - DRAW MONTH & YEAR SELECTOR
window.addEventListener("load", function () {
  // (G1) DATE NOW
  var now = new Date(),
      nowMth = now.getMonth(),
      nowYear = parseInt(now.getFullYear());

  // (G2) APPEND MONTHS SELECTOR
  var month = document.getElementById("cal-mth");
  for (var i = 0; i < 12; i++) {
    var opt = document.createElement("option");
    opt.value = i;
    opt.innerHTML = cal.mName[i];
    if (i==nowMth) { opt.selected = true; }
    month.appendChild(opt);
  }

  // (G3) APPEND YEARS SELECTOR
  // Set to 10 years range. Change this as you like.
  var year = document.getElementById("cal-yr");
  for (var i = nowYear; i<=nowYear+5; i++) {
    var opt = document.createElement("option");
    opt.value = i;
    opt.innerHTML = i;
    if (i==nowYear) { opt.selected = true; }
    year.appendChild(opt);
  }
  /* Add New Code */
	if(!localStorage.getItem("total-cost"))
	{
	localStorage.setItem("total-cost",0);
	document.getElementById("total-cost").innerText = 0;
	}
  /* End of New Code */
  // (G4) START - DRAW CALENDAR
  document.getElementById("cal-set").addEventListener("click", cal.list);
  cal.list();
});