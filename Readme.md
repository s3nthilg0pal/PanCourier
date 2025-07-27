# Quote service for an imaginary company called PanCourier

### Input
Input for the Quote service is `Consignment` that takes list of `Parcels`

### Output
Output of the Quote Service is `Quote` with collection of `lineItems` and total cost.
`LineItem` holds the type (Small|Medium|Large|ExtraLarge) and its cost.

### Parcel
Assuming all the parcel dimensions are fall into a valid size.

### Test
Some of the test are written with the help of AI

#### Promp used for generating tests
Generate unit tests for the following C# function using nUnit 3

`CODE`

Ensure the tests cover:
- Positive scenarios with various valid inputs.
- Negative scenarios including invalid inputs, edge cases (e.g., null, empty, boundary values).
- Adhere to the Arrange-Act-Assert (AAA) pattern.
- Handle error conditions and exceptions where applicable.