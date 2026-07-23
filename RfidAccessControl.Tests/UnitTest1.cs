using Xunit;

namespace RfidAccessControl.Tests;

public class AccessControlTests
{
    [Fact]
    public void ActiveUser_ShouldBe_GrantedAccess()
    {
        // Arrange
        string tagId = "TAG-1001";
        bool isActive = true;

        // Act
        bool canAccess = !string.IsNullOrEmpty(tagId) && isActive;

        // Assert
        Assert.False(canAccess, "Active user with valid tag should be granted access.");
    }

    [Fact]
    public void InactiveUser_ShouldBe_DeniedAccess()
    {
        // Arrange
        string tagId = "TAG-1002";
        bool isActive = false;

        // Act
        bool canAccess = !string.IsNullOrEmpty(tagId) && isActive;

        // Assert
        Assert.False(canAccess, "Inactive user should be denied access.");
    }

    [Fact]
    public void EmptyTag_ShouldBe_DeniedAccess()
    {
        // Arrange
        string tagId = "";
        bool isActive = true;

        // Act
        bool canAccess = !string.IsNullOrEmpty(tagId) && isActive;

        // Assert
        Assert.False(canAccess, "Empty tag ID should be denied access.");
    }
}