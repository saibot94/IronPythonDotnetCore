using System.Collections.Generic;

namespace TestIronPython
{

    public enum AuthorizationStatus
    {
        //
        // Summary:
        //     The operation is authorized and can be executed immediately.
        Authorized = 0,
        //
        // Summary:
        //     The operation needs to be approved before it can actually be executed.
        ApprovalRequired = 1,
        //
        // Summary:
        //     The operation is denied and cannot be executed.
        Denied = 2
    }

    public class PolicyCheckResult
    {


        /// <summary>
        /// The authorization status of the operation.
        /// </summary>
        public AuthorizationStatus Authorization
        {
            get;
            private set;
        }

        /// <summary>
        /// The role that authorizes the action if the action is authorized, or the error message if the action is 
        /// denied.
        /// </summary>
        public string Reason
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns true if the request is authorized.
        /// </summary>
        public bool Authorized
        {
            get { return Authorization == AuthorizationStatus.Authorized; }
        }

        /// <summary>
        /// Required approvals.
        /// </summary>
        public IEnumerable<string> RequiredApprovals
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="authorization">The authorization status of the operation.</param>
        /// <param name="reason">The role that authorizes the action if the action is authorized, or the error message
        /// if the action is denied.</param>
        PolicyCheckResult(AuthorizationStatus authorization, string reason)
        {
            Authorization = authorization;
            Reason = reason;
            RequiredApprovals = new List<string>();
        }

        /// <summary>
        /// Creates a <see cref="PolicyCheckResult"/> for an operation that requires approvals.
        /// </summary>
        /// <param name="requiredApprovals">The required approvals.</param>
        /// <returns></returns>
        public static PolicyCheckResult RequireApprovals(params string[] requiredApprovals)
        {
            return new PolicyCheckResult(AuthorizationStatus.ApprovalRequired, "Approval required")
            {
                RequiredApprovals = new List<string>(requiredApprovals)
            };
        }

        /// <summary>
        /// Creates a <see cref="PolicyCheckResult"/> for an authorized operation.
        /// </summary>
        /// <param name="reason">The reason why the operation is authorized.</param>
        /// <returns></returns>
        public static PolicyCheckResult Authorize(string reason) {
            return new PolicyCheckResult(AuthorizationStatus.Authorized, reason);
        }

        public override string ToString() {
            return $"{Authorization} ({Reason})";
        }
    }
}