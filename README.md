# PM Attendance Tracker

TODO: write a proper README

### Bot required intents / permissions

(this may change in the future)
- message content intent, server members intent (TODO: convert app to use slash commands, so we don't have to get message contents for privacy reasons?)
- view channels, send messages, add reactions (bitmask 3136)

### Docker development

`docker build -t pm-attendance-tracker:latest .`

To run, have a `.env` file locally with `BOT_TOKEN=<redacted_token>`, and run with `docker run -it --rm --env-file=.env pm-attendance-tracker:latest`

