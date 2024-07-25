// routes.enums.ts
export const RoutesEnums = {
    serviceUnavailable: "service-unavailable",
    notAuthorized: "not-authorized"
};

// payment-method.enum.ts
export enum PaymentMethod {
    CreditCard = 'CreditCard',
    PayPal = 'PayPal',
    BankTransfer = 'BankTransfer',
    CashOnDelivery = 'CashOnDelivery'
}

// shipping-method.enum.ts
export enum ShippingMethod {
    Standard = 'Standard',
    Express = 'Express',
    Overnight = 'Overnight',
    Pickup = 'Pickup'
}

// order-status.enum.ts
export enum OrderStatus {
    Pending = 'Pending',
    Processing = 'Processing',
    Shipped = 'Shipped',
    Delivered = 'Delivered',
    Canceled = 'Canceled'
}
