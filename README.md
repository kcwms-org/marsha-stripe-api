# proxy service for calling Stripe checkout
## Expectations
1. Environment Variables
    1. (REQUIRED) MARSHA_SITE_STRIPE_KEY = the Stripe api key
    1. (OPTIONAL) MARSHA_API_ALLOWED_ORIGINS = csv of origins like "https://localhost:4200,http://localhost:4200"

## Docker
1. docker build . -t kevcoder/marsha-stripe-api
1. docker run -it --rm -p 8080:80 --name marsha-stripe-api kevcoder/marsha-stripe-api