# Cross-Boundary-CorrelationId-Logging
Reference Architecture allowing use of a single CorrelationId to be used across application layers and boundaries.

# Known Issues
Using Async changes the CorrelationId upon return from any async methods. Haven't gotten around to fixing it yet. But if you're interested why this is happening checkout the linked posts below.
https://stackoverflow.com/questions/14700777/await-task-run-altering-trace-activityid-on-exit
http://sticklebackplastic.com/post/2007/08/14/One-mighty-gotcha-for-SystemDiagnostic-activity-Ids.aspx

# References
Used to help develop samples:
WebApi Without MVC: https://nodogmablog.bryanhogan.net/2017/02/web-api-without-mvc/
