CREATE DATABASE [FA24_SE1702_PRN221_G3_KoiVeterinaryServiceCenter]
GO

CREATE TABLE [Role] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(50),
  [Description] text
)
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [RoleId] int,
  [FullName] varchar(255),
  [Email] varchar(255) UNIQUE,
  [PhoneNumber] varchar(50),
  [Address] varchar(255),
  [Username] varchar(255) UNIQUE,
  [PasswordHash] varchar(255),
  [ProfilePictureUrl] varchar(255),
  [DateOfBirth] datetime,
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [Veterinarian] (
  [UserId] int PRIMARY KEY,
  [Specialization] varchar(255),
  [LicenseNumber] varchar(50),
  [YearsOfExperience] int,
  [ClinicAddress] varchar(255),
  [ProfilePictureUrl] varchar(255),
  [Rating] decimal(3,2),
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [VeterinarianAvailability] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [VeterinarianId] int,
  [AvailableDate] datetime,
  [AvailableFromTime] datetime,
  [AvailableToTime] datetime,
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [ServiceCategory] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255),
  [Description] text,
  [ServiceType] varchar(50),
  [ApplicableTo] varchar(50),
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [Service] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ServiceCategoryId] int,
  [BasePrice] decimal(10,2),
  [Duration] varchar(50),
  [ImageUrl] varchar(255),
  [StaffQuantity] int,
  [AvailableFrom] datetime,
  [AvailableTo] datetime,
  [TravelCost] decimal(10,2),
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [PetType] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [EnvironmentId] int,
  [GeneralType] varchar(50),
  [SpecificType] varchar(100)
)
GO

CREATE TABLE [Environment] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [EnvironmentType] varchar(50)
)
GO

CREATE TABLE [Pet] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] varchar(255),
  [Age] int,
  [PetTypeId] int,
  [Breed] varchar(255),
  [ImageUrl] varchar(255),
  [Color] varchar(255),
  [Length] float,
  [Weight] float,
  [Quantity] int,
  [LastHealthCheck] datetime,
  [OwnerId] int,
  [HealthStatus] int,
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [Product] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ProductCategoryId] int,
  [Name] varchar(255),
  [Description] text,
  [Price] decimal(10,2),
  [StockQuantity] int,
  [ImageUrl] varchar(255),
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [ProductCategory] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(255),
  [Description] text
)
GO

CREATE TABLE [Feedback] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ServiceId] int,
  [CustomerId] int,
  [Rating] decimal(3,2),
  [FeedbackText] text
)
GO

CREATE TABLE [Cart] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] int
)
GO

CREATE TABLE [CartItem] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CartId] int,
  [ServiceId] int,
  [ProductId] int,
  [IsDeleted] bit,
  [OrderHistoryId] int
)
GO

CREATE TABLE [Order] (
  [OrderId] int PRIMARY KEY IDENTITY(1, 1),
  [CustomerId] int,
  [TotalPrice] decimal(10,2),
  [OrderDate] datetime,
  [OrderStatus] varchar(50),
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [OrderItem] (
  [OrderItemId] int PRIMARY KEY IDENTITY(1, 1),
  [OrderId] int,
  [PetId] int,
  [ServiceId] int,
  [ProductId] int,
  [VeterinarianId] int,
  [Price] decimal(10,2),
  [TravelCost] decimal(10,2),
  [Location] varchar(255),
  [Status] varchar(50),
  [AppointmentDateTime] datetime
)
GO

CREATE TABLE [UserWallet] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int,
  [Amount] decimal(10,2),
  [LoyaltyPoints] int
)
GO

CREATE TABLE [Payment] (
  [PaymentId] int PRIMARY KEY IDENTITY(1, 1),
  [OrderId] int,
  [SystemTransactionId] int,
  [TransactionDate] datetime,
  [TotalAmount] decimal(10,2),
  [Tax] decimal(10,2),
  [CreatedAt] datetime,
  [UpdatedAt] datetime,
  [CreatedBy] varchar(255),
  [IsDeleted] bit
)
GO

CREATE TABLE [SystemTransaction] (
  [SystemTransactionId] int PRIMARY KEY IDENTITY(1, 1),
  [FromId] int,
  [ToId] int,
  [Amount] decimal(10,2),
  [TransactionType] varchar(50)
)
GO

CREATE TABLE [PetHealthRecord] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [OrderItemId] int,
  [CheckUpDate] datetime,
  [HealthStatus] varchar(255),
  [Diagnosis] text,
  [Treatment] text,
  [NextCheckUpDate] datetime,
  [Notes] text
)
GO

-- Foreign Key Constraints

ALTER TABLE [User] ADD FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id])
GO

ALTER TABLE [Veterinarian] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [VeterinarianAvailability] ADD FOREIGN KEY ([VeterinarianId]) REFERENCES [Veterinarian] ([UserId])
GO

ALTER TABLE [Service] ADD FOREIGN KEY ([ServiceCategoryId]) REFERENCES [ServiceCategory] ([Id])
GO

ALTER TABLE [PetType] ADD FOREIGN KEY ([EnvironmentId]) REFERENCES [Environment] ([Id])
GO

ALTER TABLE [Pet] ADD FOREIGN KEY ([PetTypeId]) REFERENCES [PetType] ([Id])
GO

ALTER TABLE [Pet] ADD FOREIGN KEY ([OwnerId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory] ([Id])
GO

ALTER TABLE [Feedback] ADD FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([Id])
GO

ALTER TABLE [Feedback] ADD FOREIGN KEY ([CustomerId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Cart] ADD FOREIGN KEY ([CustomerId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [CartItem] ADD FOREIGN KEY ([CartId]) REFERENCES [Cart] ([Id])
GO

ALTER TABLE [CartItem] ADD FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([Id])
GO

ALTER TABLE [CartItem] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([CustomerId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([PetId]) REFERENCES [Pet] ([Id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([ServiceId]) REFERENCES [Service] ([Id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([VeterinarianId]) REFERENCES [Veterinarian] ([UserId])
GO

ALTER TABLE [UserWallet] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Payment] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId])
GO

ALTER TABLE [Payment] ADD FOREIGN KEY ([SystemTransactionId]) REFERENCES [SystemTransaction] ([SystemTransactionId])
GO

ALTER TABLE [PetHealthRecord] ADD FOREIGN KEY ([OrderItemId]) REFERENCES [OrderItem] ([OrderItemId])
GO
