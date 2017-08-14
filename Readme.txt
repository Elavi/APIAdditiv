Possible EyesColor: { Blue, Green, Brown, Mixed }


Example runs (depends on url):


POST: http://localhost:60903/customer/add

Request: {
	
	"firstname": "Aleksandra",

	"lastname": "Snoch",

	"dateofbirth": "18-May-89",

	"eyescolor": "blue",

	"passportid":"AXD-123254-esdsdf"

}

POST: http://localhost:60903/customer/delete

Request: "AXD-123254-esdsdf"


GET: http://localhost:60903/customer/01-01-01

Response: 3
