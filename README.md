## api-variacao-ativo

This project requires .net 7, it uses clean architecture with masstransit mediator and mongo database

Access the appsettings.json, copy the connection string and test if you can connect to the mongo atlas network.

Run the application

You can test in the swagger with other assets like PETR3.SA and others that you can get with query2 of Yahoo
Routes:
POST: /Assets/load - Load the quotations of the asset in the database
payload:
```json
{
  "symbol": "string"
}
```
response: 204 - No Content

GET: /Assets/{symbol}/Quotations?startsAt={dateTime}&endsAt={dateTime}&withVariation={boolean} - Get the quotations of the asset
response: 200
```json
[
  {
    "quotations": [
      {
        "id": "string",
        "day": "2023-03-23T06:36:42.133Z",
        "close": 0,
        "closeVariation": 0,
        "open": 0,
        "openVariation": 0,
        "high": 0,
        "highVariation": 0,
        "low": 0,
        "lowVariation": 0,
        "volume": 0,
        "volumeVariation": 0
      }
    ]
  }
]
```


