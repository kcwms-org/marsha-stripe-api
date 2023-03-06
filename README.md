# proxy service for calling Stripe checkout
## Expectations
1. Environment Variables
    1. MARSHASTRIPEAPI_ALLOWEDORIGINS = csv or origins like "https://localhost:4200,http://localhost:4200"

## Docker
1. docker build . -t kevcoder/marsha-stripe-api
1. docker run -it --rm -p 8080:80 --name marsha-stripe-api kevcoder/marsha-stripe-api