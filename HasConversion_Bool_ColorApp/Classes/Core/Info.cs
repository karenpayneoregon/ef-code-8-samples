using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace HasConversion_Bool_ColorApp.Classes.Core
{
    /// <summary>
    /// Provides utility methods to retrieve assembly metadata (company, product, copyright, version)
    /// and (optionally) details about the caller that invoked each method.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// Represents details about the caller of a method, including assembly information,
        /// target framework, type and method names, file path, and line number.
        /// </summary>
        public readonly record struct CallerDetails(string? AssemblyName, string? AssemblyVersion,
            string? TargetFramework, string? TypeName, string? MethodName, string? FilePath, int LineNumber);

        // Build caller details. Use Caller Info attrs for member/file/line;
        // use GetCallingAssembly for the assembly; use StackTrace for type.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static CallerDetails BuildCallerDetails(string? memberName, string? filePath, int lineNumber)
        {
            var callingAsm = Assembly.GetCallingAssembly();
            string? typeName = null;

            try
            {
                // Skip this helper frame; capture the immediate external frame.
                var st = new StackTrace(skipFrames: 1, fNeedFileInfo: false);
                var frame = st.GetFrame(0);
                typeName = frame?.GetMethod()?.DeclaringType?.FullName;
            }
            catch
            {
                // Best-effort; leave typeName null if anything goes sideways.
            }

            var asmName = callingAsm.GetName();
            var framework = callingAsm.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            return new CallerDetails(
                AssemblyName: asmName?.Name,
                AssemblyVersion: asmName?.Version?.ToString(),
                TargetFramework: framework,
                TypeName: typeName,
                MethodName: memberName,
                FilePath: filePath,
                LineNumber: lineNumber);
        }


        /// <summary>
        /// Retrieves the copyright information associated with the calling assembly.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> containing the copyright information, or "No copyright information found" 
        /// if the copyright is not specified in the assembly metadata.
        /// </returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCopyright()
        {
            var asm = Assembly.GetCallingAssembly();
            var attr = asm.GetCustomAttribute<AssemblyCopyrightAttribute>();
            return attr?.Copyright ?? "No copyright information found.";
        }

        /// <summary>
        /// Retrieves the company name associated with the calling assembly.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> containing the company name, or "No company information found" 
        /// if the company name is not specified in the assembly metadata.
        /// </returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCompany()
        {
            var asm = Assembly.GetCallingAssembly();
            var attr = asm.GetCustomAttribute<AssemblyCompanyAttribute>();

            return attr?.Company ?? "No company information found.";
        }

        /// <summary>
        /// Retrieves the description information associated with the calling assembly.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> containing the description information, or "No description found" 
        /// if the description is not specified in the assembly metadata.
        /// </returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDescription()
        {
            var asm = Assembly.GetCallingAssembly();
            var attr = asm.GetCustomAttribute<AssemblyDescriptionAttribute>();

            return attr?.Description ?? "No description found.";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCompany(
            out CallerDetails caller,
            [CallerMemberName] string? memberName = null,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            caller = BuildCallerDetails(memberName, filePath, lineNumber);
            return GetCompany();
        }

        // -----------------------
        // PRODUCT
        // -----------------------

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetProduct()
        {
            var asm = Assembly.GetCallingAssembly();
            var attr = asm.GetCustomAttribute<AssemblyProductAttribute>();
            return attr?.Product ?? "No product information found.";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetProduct(
            out CallerDetails caller,
            [CallerMemberName] string? memberName = null,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            caller = BuildCallerDetails(memberName, filePath, lineNumber);
            return GetProduct();
        }

        // -----------------------
        // VERSION
        // -----------------------

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Version GetVersion()
        {
            var asm = Assembly.GetCallingAssembly();
            return asm.GetName().Version ?? new Version(1, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Version GetVersion(
            out CallerDetails caller,
            [CallerMemberName] string? memberName = null,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            caller = BuildCallerDetails(memberName, filePath, lineNumber);
            return GetVersion();
        }

        /// <summary>
        /// Retrieves the build date of the calling assembly from its metadata.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> containing the build date if it is specified in the assembly metadata,
        /// or <see langword="null"/> if the build date is not found.
        /// </returns>
        public static string? GetBuildDate()
        {
            var asm = Assembly.GetCallingAssembly();

            var attr = asm
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(a => a.Key == "BuildDate");

            return attr?.Value;
        }

        public static DateOnly BuildDate()
        {
            var buildDate = GetBuildDate();
            if (buildDate is not null && DateOnly.TryParse(buildDate, out var dateOnly))
            {
                return dateOnly;
            }

            return default;
        }

        /// <summary>
        /// Retrieves the build date of the calling assembly from its metadata, optionally including caller details.
        /// </summary>
        /// <param name="caller">Output parameter to receive caller details.</param>
        /// <param name="memberName">The name of the member calling this method (automatically provided).</param>
        /// <param name="filePath">The full path of the source file calling this method (automatically provided).</param>
        /// <param name="lineNumber">The line number in the source file where this method is called (automatically provided).</param>
        /// <returns>
        /// A <see cref="DateOnly"/> representing the build date if found, otherwise <see langword="default"/> (<see cref="DateOnly.MinValue"/>).
        /// </returns>
        public static DateOnly BuildDate(out CallerDetails caller, [CallerMemberName] string? memberName = null,
            [CallerFilePath] string? filePath = null, [CallerLineNumber] int lineNumber = 0)
        {
            caller = BuildCallerDetails(memberName, filePath, lineNumber);
            return BuildDate();


        }
    }
}
