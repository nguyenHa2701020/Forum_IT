using Microsoft.AspNetCore.Identity;

namespace ForumIT.Models.Domain
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}






































/*
 * ----------------------Thuộc tính UserManager
 * AccessFailedAsync(TUser)
Tăng số lượng truy cập không thành công cho người dùng dưới dạng hoạt động không đồng bộ. Nếu tài khoản truy cập không thành công lớn hơn hoặc bằng số lần thử tối đa đã được định cấu hình, người dùng sẽ bị khóa trong khoảng thời gian khóa đã định cấu hình.

AddClaimAsync(TNgười dùng, Yêu cầu)
Thêm xác nhận quyền sở hữu được chỉ định cho người dùng.

AddClaimsAsync(TUser, IEnumerable<Claim>)
Thêm các xác nhận quyền sở hữu được chỉ định cho người dùng.

AddLoginAsync(TUser, UserLoginInfo)
Thêm UserLoginInfo bên ngoài vào người dùng được chỉ định.

AddPasswordAsync(TUser, String)
Chỉ thêm mật khẩu cho người dùng được chỉ định nếu người dùng chưa có mật khẩu.

AddToRoleAsync(TUser, Chuỗi)
Thêm người dùng được chỉ định vào vai trò được đặt tên.

AddToRolesAsync(TUser, IEnumerable<String>)
Thêm người dùng được chỉ định vào các vai trò được đặt tên.

ChangeEmailAsync(TUser, String, String)
Cập nhật email của người dùng nếu mã thông báo thay đổi email được chỉ định hợp lệ cho người dùng.

ChangePasswordAsync(TUser, String, String)
Thay đổi mật khẩu của người dùng sau khi xác nhận currentPassword được chỉ định là chính xác, dưới dạng hoạt động không đồng bộ.

ChangePhoneNumberAsync(TUser, String, String)
Đặt số điện thoại cho người dùng được chỉ định nếu mã thông báo thay đổi được chỉ định hợp lệ.

CheckPasswordAsync(TUser, String)
Trả về cờ cho biết mật khẩu đã cho có hợp lệ đối với người dùng đã chỉ định hay không.

Xác nhậnEmailAsync(TUser, String)
Xác thực rằng mã thông báo xác nhận email khớp với người dùng được chỉ định.

CountRecoveryCodesAsync(TUser)
Trả về số lượng mã khôi phục vẫn hợp lệ đối với người dùng.

CreateAsync(TUser)
Tạo người dùng được chỉ định trong kho lưu trữ dự phòng không có mật khẩu, dưới dạng hoạt động không đồng bộ.

CreateAsync(TUser, String)
Tạo người dùng được chỉ định trong kho lưu trữ dự phòng bằng mật khẩu đã cho, dưới dạng hoạt động không đồng bộ.

CreateSecurityTokenAsync(TUser)
Tạo byte để sử dụng làm mã thông báo bảo mật từ tem bảo mật của người dùng.

CreateTwoFactorRecoveryCode()
Tạo mã khôi phục mới.

XóaAsync(TUser)
Xóa người dùng được chỉ định khỏi cửa hàng sao lưu.

Vứt bỏ()
Giải phóng tất cả các tài nguyên được sử dụng bởi người quản lý người dùng.

Vứt bỏ(Boolean)
Giải phóng các tài nguyên không được quản lý được người quản lý vai trò sử dụng và tùy ý giải phóng các tài nguyên được quản lý.

FindByEmailAsync(Chuỗi)
Nhận người dùng, nếu có, được liên kết với giá trị chuẩn hóa của địa chỉ email được chỉ định. Lưu ý: Chúng tôi khuyên bạn nên đặt IdentityOptions.User.RequireUniqueEmail thành true khi sử dụng phương pháp này, nếu không cửa hàng có thể loại bỏ nếu có người dùng có email trùng lặp.

FindByIdAsync(Chuỗi)
Tìm và trả về một người dùng, nếu có, có userId được chỉ định.

FindByLoginAsync(Chuỗi, Chuỗi)
Truy xuất người dùng được liên kết với nhà cung cấp thông tin đăng nhập bên ngoài và khóa nhà cung cấp thông tin đăng nhập được chỉ định.

FindByNameAsync(Chuỗi)
Tìm và trả về một người dùng, nếu có, có tên người dùng được chỉ định.

TạoChangeEmailTokenAsync(TUser, String)
Tạo mã thông báo thay đổi email cho người dùng được chỉ định.

TạoChangePhoneNumberTokenAsync(TUser, String)
Tạo mã thông báo thay đổi số điện thoại cho người dùng được chỉ định.

TạoConcurrencyStampAsync(TUser)
Tạo ra một giá trị phù hợp để sử dụng trong theo dõi đồng thời.

TạoEmailConfirmationTokenAsync(TUser)
Tạo mã thông báo xác nhận email cho người dùng được chỉ định.

TạoNewAuthenticatorKey()
Tạo bí mật bảo mật 160-bit được mã hóa base32 mới (kích thước của hàm băm SHA1).

TạoNewTwoFactorRecoveryCodesAsync(TUser, Int32)
Tạo mã khôi phục cho người dùng, điều này làm mất hiệu lực mọi mã khôi phục trước đó của người dùng.

TạoPasswordResetTokenAsync(TUser)
Tạo mã thông báo đặt lại mật khẩu cho người dùng được chỉ định, sử dụng nhà cung cấp mã thông báo đặt lại mật khẩu đã định cấu hình.

TạoTwoFactorTokenAsync(TUser, String)
Nhận mã thông báo xác thực hai yếu tố cho người dùng được chỉ định.

TạoUserTokenAsync(TUser, Chuỗi, Chuỗi)
Tạo mã thông báo cho người dùng và mục đích nhất định.

GetAccessFailedCountAsync(TUser)
Truy xuất số lần truy cập không thành công hiện tại của người dùng nhất định.

GetAuthenticationTokenAsync(TUser, String, String)
Trả về mã thông báo xác thực cho người dùng.

GetAuthenticatorKeyAsync(TUser)
Trả về khóa xác thực cho người dùng.

GetChangeEmailTokenPurpose(Chuỗi)
Tạo mục đích mã thông báo được sử dụng để thay đổi email.

GetClaimsAsync(TUser)
Nhận danh sách các Xác nhận quyền sở hữu thuộc về người dùng được chỉ định dưới dạng hoạt động không đồng bộ.

GetEmailAsync(TUser)
Nhận địa chỉ email cho người dùng được chỉ định.

GetLockoutEnabledAsync(TUser)
Truy xuất cờ cho biết liệu khóa người dùng có thể được bật cho người dùng được chỉ định hay không.

GetLockoutEndDateAsync(TUser)
Lấy DateTimeOffset lần khóa cuối cùng của người dùng đã hết hạn, nếu có. Giá trị thời gian trong quá khứ cho biết người dùng hiện không bị khóa.

GetLoginsAsync(TUser)
Truy xuất thông tin đăng nhập liên quan cho tệp .

GetPhoneNumberAsync(TUser)
Lấy số điện thoại, nếu có, của người dùng được chỉ định.

GetRolesAsync(TUser)
Nhận danh sách tên vai trò của người dùng được chỉ định.

GetSecurityStampAsync(TUser)
Nhận tem bảo mật

GetTwoFactorEnabledAsync(TUser)
Trả về cờ cho biết người dùng được chỉ định có bật xác thực hai yếu tố hay không, dưới dạng hoạt động không đồng bộ.

GetUserAsync(ClaimsPrincipal)
Trả về người dùng tương ứng với xác nhận quyền sở hữu IdentityOptions.ClaimsIdentity.UserIdClaimType ở dạng gốc hoặc null.

GetUserId(ClaimsPrincipal)
Trả về giá trị xác nhận User ID nếu có, nếu không thì trả về giá trị rỗng.

GetUserIdAsync(TUser)
Lấy mã định danh người dùng cho người dùng được chỉ định.

GetUserName(ClaimsPrincipal)
Trả về giá trị yêu cầu Tên nếu có, nếu không thì trả về null.

GetUserNameAsync(TUser)
Lấy tên người dùng cho người dùng được chỉ định.

GetUsersForClaimAsync(Xác nhận quyền sở hữu)
Trả về danh sách người dùng từ cửa hàng người dùng có xác nhận quyền sở hữu được chỉ định.

GetUsersInRoleAsync(Chuỗi)
Trả về danh sách người dùng từ cửa hàng người dùng là thành viên của Tên vai trò được chỉ định.

GetValidTwoFactorProvidersAsync(TUser)
Nhận danh sách các nhà cung cấp mã thông báo hai yếu tố hợp lệ cho người dùng được chỉ định, dưới dạng hoạt động không đồng bộ.

HasPasswordAsync(TUser)
Nhận cờ cho biết người dùng được chỉ định có mật khẩu hay không.

IsEmailConfirmedAsync(TUser)
Nhận cờ cho biết địa chỉ email của người dùng được chỉ định đã được xác minh hay chưa, đúng nếu địa chỉ email được xác minh nếu không là sai.

IsInRoleAsync(TUser, String)
Trả về cờ cho biết người dùng được chỉ định có phải là thành viên của vai trò được đặt tên hay không.

IsLockedOutAsync(TUser)
Trả về cờ cho biết liệu người dùng được chỉ định có bị khóa hay không, dưới dạng hoạt động không đồng bộ.

IsPhoneNumberConfirmedAsync(TUser)
Nhận cờ cho biết số điện thoại của người dùng được chỉ định đã được xác nhận hay chưa.

Chuẩn hóaEmail(Chuỗi)
Chuẩn hóa email để so sánh nhất quán.

NormalizeName(Chuỗi)
Chuẩn hóa tên người dùng hoặc vai trò để so sánh nhất quán.

RedeemTwoFactorRecoveryCodeAsync(TUser, String)
Trả về xem mã khôi phục có hợp lệ đối với người dùng hay không. Lưu ý: mã khôi phục chỉ có hiệu lực một lần và sẽ không hợp lệ sau khi sử dụng.

RegisterTokenProvider(Chuỗi, IUserTwoFactorTokenProvider<TUser>)
Đăng ký nhà cung cấp mã thông báo.

RemoveAuthenticationTokenAsync(TUser, String, String)
Xóa mã thông báo xác thực cho người dùng.

RemoveClaimAsync(TUser, Claim)
Xóa xác nhận quyền sở hữu được chỉ định khỏi người dùng nhất định.

RemoveClaimsAsync(TUser, IEnumerable<Claim>)
Xóa các xác nhận quyền sở hữu được chỉ định khỏi người dùng nhất định.

RemoveFromRoleAsync(TUser, String)
Xóa người dùng được chỉ định khỏi vai trò được đặt tên.

RemoveFromRolesAsync(TUser, IEnumerable<String>)
Xóa người dùng được chỉ định khỏi các vai trò được đặt tên.

RemoveLoginAsync(TUser, String, String)
Cố gắng xóa thông tin đăng nhập bên ngoài được cung cấp khỏi người dùng được chỉ định. và trả về một cờ cho biết việc xóa có thành công hay không.

RemovePasswordAsync(TUser)
Xóa mật khẩu của người dùng.

Thay thếClaimAsync(TUser, Khiếu nại, Khiếu nại)
Thay thế xác nhận quyền sở hữu đã cho đối với người dùng được chỉ định bằng newClaim

ResetAccessFailedCountAsync(TUser)
Đặt lại số lần truy cập không thành công cho người dùng được chỉ định.

Đặt lạiAuthenticatorKeyAsync(TUser)
Đặt lại khóa xác thực cho người dùng.

ResetPasswordAsync(TUser, String, String)
Đặt lại mật khẩu của người dùng thành newPassword đã chỉ định sau khi xác thực mã thông báo đặt lại mật khẩu đã cho.

SetAuthenticationTokenAsync(TUser, Chuỗi, Chuỗi, Chuỗi)
Đặt mã thông báo xác thực cho người dùng.

SetEmailAsync(TUser, Chuỗi)
Đặt địa chỉ email cho người dùng.

SetLockoutEnabledAsync(TUser, Boolean)
Đặt cờ cho biết liệu người dùng được chỉ định có bị khóa hay không, dưới dạng hoạt động không đồng bộ.

SetLockoutEndDateAsync(TUser, Nullable<DateTimeOffset>)
Khóa người dùng cho đến khi ngày kết thúc được chỉ định trôi qua. Việc đặt ngày kết thúc trong quá khứ sẽ ngay lập tức mở khóa người dùng.

SetPhoneNumberAsync(TUser, Chuỗi)
Đặt số điện thoại cho người dùng được chỉ định.

SetTwoFactorEnabledAsync(TUser, Boolean)
Đặt cờ cho biết người dùng được chỉ định có bật xác thực hai yếu tố hay không, dưới dạng hoạt động không đồng bộ.

SetUserNameAsync(TUser, Chuỗi)
Đặt tên người dùng đã cho cho người dùng được chỉ định.

ThrowIfDispose()
Ném nếu lớp này đã được xử lý.

UpdateAsync(TUser)
Cập nhật người dùng được chỉ định trong cửa hàng hỗ trợ.

Cập nhậtNormalizedEmailAsync(TUser)
Cập nhật email chuẩn hóa cho người dùng được chỉ định.

Cập nhậtNormalizedUserNameAsync(TUser)
Cập nhật tên người dùng chuẩn hóa cho người dùng được chỉ định.

UpdatePasswordHash(TUser, String, Boolean)
Cập nhật hàm băm mật khẩu của người dùng.

UpdateSecurityStampAsync(TUser)
Tạo lại tem bảo mật cho người dùng được chỉ định.

UpdateUserAsync(TUser)
Được gọi để cập nhật người dùng sau khi xác thực và cập nhật email/tên người dùng đã chuẩn hóa.

Xác thựcPasswordAsync(TUser, String)
Nên trả về Thành công nếu xác thực thành công. Điều này được gọi trước khi cập nhật hàm băm mật khẩu.

Xác thựcUserAsync(TUser)
Nên trả về Thành công nếu xác thực thành công. Điều này được gọi trước khi lưu người dùng thông qua Tạo hoặc Cập nhật.

VerifyChangePhoneNumberTokenAsync(TUser, String, String)
Trả về một cờ cho biết liệu u được chỉ định

VerifyPasswordAsync(IUserPasswordStore<TUser>, TUser, String)
Trả về một kết quả xác minh mật khẩu cho biết kết quả so sánh hàm băm mật khẩu.

VerifyTwoFactorTokenAsync(TUser, String, String)
Xác minh mã thông báo xác thực hai yếu tố được chỉ định đối với người dùng.

VerifyUserTokenAsync(TUser, String, String, String)
Trả về cờ cho biết mã thông báo đã chỉ định có hợp lệ cho người dùng và mục đích nhất định hay không.

---------------------------Sigin Mânge
AddClaimAsync(TRole, Xác nhận quyền sở hữu)
Thêm yêu cầu cho một vai trò.

CreateAsync(TRole)
Tạo vai trò được chỉ định trong kho lưu trữ kiên trì.

DeleteAsync(TRole)
Xóa vai trò được chỉ định.

Vứt bỏ()
Giải phóng tất cả các tài nguyên được người quản lý vai trò sử dụng.

Dispose(Boolean)
Giải phóng các tài nguyên không được quản lý được người quản lý vai trò sử dụng và tùy ý giải phóng các tài nguyên được quản lý.

FindByIdAsync(Chuỗi)
Tìm vai trò được liên kết với Id vai trò đã chỉ định nếu có.

FindByNameAsync(Chuỗi)
Tìm vai trò được liên kết với Tên vai trò được chỉ định nếu có.

GetClaimsAsync(TRole)
Nhận danh sách các yêu cầu liên quan đến vai trò được chỉ định.

GetRoleIdAsync(TRole)
Nhận ID của vai trò được chỉ định.

GetRoleNameAsync(TRole)
Lấy tên của vai trò được chỉ định.

NormalizeKey(Chuỗi)
Nhận một biểu diễn chuẩn hóa của khóa được chỉ định.

RemoveClaimAsync(TRole, Claim)
Xóa yêu cầu khỏi một vai trò.

Vai tròExistsAsync(Chuỗi)
Nhận cờ cho biết vai trò được chỉ định có tồn tại hay không.

SetRoleNameAsync(TRole, Chuỗi)
Đặt tên của vai trò được chỉ định.

ThrowIfDispose()
Ném nếu lớp này đã được xử lý.

Cập nhậtAsync(TRole)
Cập nhật vai trò được chỉ định.

UpdateNormalizedRoleNameAsync(TRole)
Cập nhật tên chuẩn hóa cho vai trò đã chỉ định.

UpdateRoleAsync(TRole)
Được gọi để cập nhật vai trò sau khi xác thực và cập nhật tên vai trò đã chuẩn hóa.

Xác thựcRoleAsync(TRole)
Nên trả về Thành công nếu xác thực thành công. Điều này được gọi trước khi lưu vai trò thông qua Tạo hoặc Cập nhật.

------------------------------------SiginManaager
CanSignInAsync(TUser)
Trả về cờ cho biết người dùng được chỉ định có thể đăng nhập hay không.

CheckPasswordSignInAsync(TUser, String, Boolean)
Cố gắng đăng nhập bằng mật khẩu cho người dùng.

ConfigureExternalAuthenticationProperties(Chuỗi, Chuỗi, Chuỗi)
Định cấu hình URL chuyển hướng và mã định danh người dùng cho nhà cung cấp thông tin đăng nhập bên ngoài được chỉ định.

CreateUserPrincipalAsync(TUser)
Tạo ClaimsPrincipal cho người dùng được chỉ định, dưới dạng hoạt động không đồng bộ.

ExternaiLoginSignInAsync(Chuỗi, Chuỗi, Boolean)
Đăng nhập người dùng thông qua thông tin đăng nhập của bên thứ ba đã đăng ký trước đó, dưới dạng hoạt động không đồng bộ.

Bên ngoàiLoginSignInAsync(Chuỗi, Chuỗi, Boolean, Boolean)
Đăng nhập người dùng thông qua thông tin đăng nhập của bên thứ ba đã đăng ký trước đó, dưới dạng hoạt động không đồng bộ.

ForgetTwoFactorClientAsync()
Xóa "Ghi nhớ cờ trình duyệt này" khỏi trình duyệt hiện tại dưới dạng hoạt động không đồng bộ.

GetExternalAuthenticationSchemesAsync()
Nhận một bộ sưu tập các Sơ đồ xác thực cho các nhà cung cấp thông tin đăng nhập bên ngoài đã biết.

GetExternalLoginInfoAsync(Chuỗi)
Nhận thông tin đăng nhập bên ngoài cho lần đăng nhập hiện tại, dưới dạng hoạt động không đồng bộ.

GetTwoFactorAuthenticationUserAsync()
Lấy TUser cho thông tin đăng nhập xác thực hai yếu tố hiện tại, dưới dạng hoạt động không đồng bộ.

IsLockedOut(TUser)
Được sử dụng để xác định xem người dùng có bị coi là bị khóa hay không.

IsSignedIn(ClaimsPrincipal)
Trả về true nếu hiệu trưởng có danh tính bằng danh tính cookie ứng dụng

IsTwoFactorClientRememberedAsync(TUser)
Trả về cờ cho biết liệu trình duyệt máy khách hiện tại có được ghi nhớ bằng xác thực hai yếu tố đối với người dùng đang cố đăng nhập hay không, dưới dạng hoạt động không đồng bộ.

LockedOut(TUser)
Trả về SignInResult bị khóa.

PasswordSignInAsync(Chuỗi, Chuỗi, Boolean, Boolean)
Cố gắng đăng nhập bằng cách kết hợp Tên người dùng và mật khẩu được chỉ định dưới dạng hoạt động không đồng bộ.

PasswordSignInAsync(TUser, Chuỗi, Boolean, Boolean)
Cố gắng đăng nhập bằng tổ hợp người dùng và mật khẩu được chỉ định dưới dạng hoạt động không đồng bộ.

PreSignInCheck(TUser)
Được sử dụng để đảm bảo rằng người dùng được phép đăng nhập.

RefreshSignInAsync(TUser)
Đăng nhập vào người dùng được chỉ định, trong khi vẫn duy trì Thuộc tính xác thực hiện có của người dùng đã đăng nhập hiện tại như RememberMe, dưới dạng hoạt động không đồng bộ.

RememberTwoFactorClientAsync(TUser)
Đặt cờ trên trình duyệt để cho biết người dùng đã chọn "Ghi nhớ trình duyệt này" cho mục đích xác thực hai yếu tố, dưới dạng hoạt động không đồng bộ.

ResetLockout(TUser)
Được sử dụng để đặt lại số lần khóa của người dùng.

SignInAsync(TUser, AuthenticationProperties, String)
Dấu hiệu trong người dùng được chỉ định.

SignInAsync(TUser, Boolean, String)
Dấu hiệu trong người dùng được chỉ định.

SignInOrTwoFactorAsync(TUser, Boolean, String, Boolean)
Đăng nhập vào người dùng được chỉ định nếu bypassTwoFactor được đặt thành false. Nếu không thì lưu trữ người dùng để sử dụng sau khi kiểm tra hai yếu tố.

SignInWithClaimsAsync(TUser, AuthenticationProperties, IEnumerable<Claim>)
Dấu hiệu trong người dùng được chỉ định.

SignInWithClaimsAsync(TUser, Boolean, IEnumerable<Claim>)
Dấu hiệu trong người dùng được chỉ định.

SignOutAsync()
Đăng xuất người dùng hiện tại khỏi ứng dụng.

TwoFactorAuthenticatorSignInAsync(Chuỗi, Boolean, Boolean)
Xác thực mã đăng nhập từ một ứng dụng xác thực, đồng thời tạo và đăng nhập vào người dùng dưới dạng hoạt động không đồng bộ.

TwoFactorRecoveryCodeSignInAsync(Chuỗi)
Đăng nhập người dùng mà không cần xác thực hai yếu tố bằng mã khôi phục hai yếu tố.

TwoFactorSignInAsync(Chuỗi, Chuỗi, Boolean, Boolean)
Xác thực mã đăng nhập hai yếu tố, đồng thời tạo và đăng nhập vào người dùng dưới dạng hoạt động không đồng bộ.

UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo)
Lưu trữ mọi mã thông báo xác thực được tìm thấy trong cookie xác thực bên ngoài vào người dùng được liên kết.

ValidateSecurityStampAsync(ClaimsPrincipal)
Xác thực tem bảo mật cho hiệu trưởng được chỉ định so với tem duy trì cho người dùng hiện tại, dưới dạng hoạt động không đồng bộ.

ValidateSecurityStampAsync(TUser, String)
Xác thực tem bảo mật cho người dùng được chỉ định. Nếu không có người dùng nào được chỉ định hoặc nếu cửa hàng không hỗ trợ tem bảo mật thì việc xác thực được coi là thành công.

ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal)
Xác thực tem bảo mật cho hiệu trưởng được chỉ định từ một trong hai yếu tố chính (nhớ id khách hàng hoặc id người dùng) đối với tem tồn tại cho người dùng hiện tại, dưới dạng hoạt động không đồng bộ.
​

 */
