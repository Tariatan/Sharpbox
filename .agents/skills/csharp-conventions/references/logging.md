# Logging

## Logs Should Tell a Coherent Story

- If events or activities belong together, create logs in the same style.
- On a pair review about logs, don't just review the code — check the current log output too:
  - the log matches the complexity level of similar existing logs
  - the log uses the same style as similar existing logs
  - the logs read like a story of what happened on the system
- Apply continuous refactoring to logging; it's craft, not science.

## Log Levels

| Level | Name              | Meaning                                                                                                                                               |
| ----- | ----------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| F     | Emergency (Fatal) | System is unusable                                                                                                                                    |
| E     | Error             | A problem has occurred, from which the system cannot recover                                                                                          |
| W     | Warning           | A problem is imminent (e.g. a resource like disk space runs out) or an unexpected situation that does not cause an error                              |
| N     | Notice            | A problem occurred and the system recovered by itself, or something is not as expected but has no impact on operational status — still worth checking |
| I     | Information       | Tells the story of what happened on the system: state changes, events/requests/responses, workflows, user actions, ...                                |
| D     | Debug             | Development-time investigation of technical problems (race conditions, memory leaks, etc.)                                                            |

- Production deployments run at maximum log level **Information**.
- Error, Warning, and Information logs together should let a developer reconstruct what happened on a system.
- Error and Warning are for **unexpected** situations only.
- **Expected** situations — even failure-like ones (e.g. "not enough reagent to start a run") — are Information, not Error/Warning.
- A bug-free system running under normal conditions should produce zero Error or Warning logs.

## Log Start and End of Long-Running Activities

- Start: `Doing something ...`
- End: `Finished something`

```csharp
this.logger.Information("Uploading terminator AI backup 'T123' to 'Skynet' ...");
...
this.logger.Information("Terminator AI backup 'T123' successfully uploaded to 'Skynet'");
```

## Log Events, Commands, and Requests

- Log every published event and every handled event (`IHandleEvent` or Rx stream aggregation).
- Log every sent and handled command.
- Log every request and response, both when sent and when handled.
- Use the logging library's extension methods for this instead of hand-rolling the format.

## Log All Relevant Data as Part of the Message

- Log the parameters of a parameterized operation.
- Exclude binary data or huge structures from the log (use the library's exclude-names helpers).
- Log the message content for events/requests/responses.
- For long-running activities: log the input plus an identifier on the start log, and the outcome plus the same identifier on the end log.
- If an exception is missing important data (e.g. a file path), add it to the log message.
- Information logs: trace as little as necessary — they're frequent and too much detail clutters the output.
- Error/Warning logs: log everything you can find — they're rare and someone will need to investigate.

## Log the Same Data the Same Way

- Logs for the same kind of complex object use the same data and structure every time.
- If you log a complex object's contents, implement `ToString` and use it to build that part of the message.

## Use Separators Consistently

- No trailing dot at the end of a log message.
- Use `'...'` to wrap values: `State has changed from 'Standby' to 'Error'`.
- Comma-separate multiple values: `Measurement values: '23.1 kg', '13.3 kg', '5.2 kg'`.
- Always use `<Name>: '<Value>'` for named values (property name, colon, space, single-quoted value).
- Never use `" | { } [ ] ;` as field/data separators (table-formatted log output is the exception).
- Use `ObjectLogger` to log DTOs/objects/events — it recursively logs all public properties, including collections.
- Use `IndentedObjectLogger` for a structured, indented rendering of the same data.
